using Nereid.FinalFrontier;
using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace FinalFrontiersExporter
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    public class RibbonExporter : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F8) && Input.GetKey(KeyCode.LeftControl))
            {
                Export();
            }
        }

        public void Export()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><body>");

            HallOfFame instance = HallOfFame.Instance();
            foreach (ProtoCrewMember kerbal in HighLogic.CurrentGame.CrewRoster.Crew)
            {
                HallOfFameEntry entry = instance.GetEntry(kerbal);
                if (entry == null) continue;

                sb.Append($"<h2>{kerbal.name}</h2>");

                foreach (Ribbon ribbon in entry.GetRibbons())
                {
                    string name = ribbon.GetName();
                    string desc = ribbon.GetDescription();
                    Texture2D tex = ribbon.GetTexture();

                    byte[] png = tex.EncodeToPNG();
                    string b64 = Convert.ToBase64String(png);

                    sb.Append($"<img src='data:image/png;base64,{b64}'> {name} - {desc}<br>");
                }
            }

            sb.Append("</body></html>");

            string path = Path.Combine(KSPUtil.ApplicationRootPath, "ribbons.html");
            File.WriteAllText(path, sb.ToString());

            ScreenMessages.PostScreenMessage($"Ribbons exported successfully.\n\n{path}", 5f, ScreenMessageStyle.UPPER_CENTER);
        }
    }
}