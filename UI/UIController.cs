using System.IO;
using System.Reflection;
using BepInEx;
using EvilMask.Elin.ModOptions;
using EvilMask.Elin.ModOptions.UI;

namespace QualityFishing
{
    public class UIController
    {
        public static void RegisterUI()
        {
            foreach (var obj in ModManager.ListPluginObject)
            {
                if (obj is BaseUnityPlugin plugin && plugin.Info.Metadata.GUID == ModInfo.ModOptionsGuid)
                {
                    var controller = ModOptionController.Register(guid: ModInfo.Guid, tooptipId: "mod.tooltip");
                    
                    var assemblyLocation = Path.GetDirectoryName(path: Assembly.GetExecutingAssembly().Location);
                    var xmlPath = Path.Combine(path1: assemblyLocation, path2: "QualityFishingConfig.xml");
                    QualityFishingConfig.InitializeXmlPath(xmlPath: xmlPath);
            
                    var xlsxPath = Path.Combine(path1: assemblyLocation, path2: "translations.xlsx");
                    QualityFishingConfig.InitializeTranslationXlsxPath(xlsxPath: xlsxPath);
                    
                    if (File.Exists(path: QualityFishingConfig.XmlPath))
                    {
                        using (StreamReader sr = new StreamReader(path: QualityFishingConfig.XmlPath))
                            controller.SetPreBuildWithXml(xml: sr.ReadToEnd());
                    }
                    
                    if (File.Exists(path: QualityFishingConfig.TranslationXlsxPath))
                    {
                        controller.SetTranslationsFromXslx(path: QualityFishingConfig.TranslationXlsxPath);
                    }
                    
                    RegisterEvents(controller: controller);
                }
            }
        }

        private static void RegisterEvents(ModOptionController controller)
        {
            controller.OnBuildUI += builder =>
            {
                var enableQualityToggle = builder.GetPreBuild<OptToggle>(id: "enableQualityToggle");
                enableQualityToggle.Checked = QualityFishingConfig.EnableQuality.Value;
                enableQualityToggle.OnValueChanged += isChecked =>
                {
                    QualityFishingConfig.EnableQuality.Value = isChecked;
                };
                
                var enableLevelToggle = builder.GetPreBuild<OptToggle>(id: "enableLevelToggle");
                enableLevelToggle.Checked = QualityFishingConfig.EnableLevel.Value;
                enableLevelToggle.OnValueChanged += isChecked =>
                {
                    QualityFishingConfig.EnableLevel.Value = isChecked;
                };
                
                var enableVanillaLevelScalingToggle = builder.GetPreBuild<OptToggle>(id: "enableVanillaLevelScalingToggle");
                enableVanillaLevelScalingToggle.Checked = QualityFishingConfig.EnableVanillaLevelScaling.Value;
                enableVanillaLevelScalingToggle.OnValueChanged += isChecked =>
                {
                    QualityFishingConfig.EnableVanillaLevelScaling.Value = isChecked;
                };
                
                var slider = builder.GetPreBuild<OptSlider>(id: "slider01");
                slider.Title = QualityFishingConfig.LevelScaling.Value.ToString();
                slider.Value = QualityFishingConfig.LevelScaling.Value;
                slider.Step = 1;
                slider.OnValueChanged += v =>
                {
                    slider.Title = v.ToString();
                    QualityFishingConfig.LevelScaling.Value = (int)v;
                };
            };
        }
    }
}