using System;
using System.Collections;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Unity.Mono;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace GayASSUnityGUITemp
{
    [BepInPlugin("org.GalaxizsOnGuiTemp", "Ex", "1.0.0.0")]
    //This shitty ass temp was made by galaxizs you nigger
    public class GalaxizsTemp : BaseUnityPlugin
    {
        /// Please answer these! !! ! ! !  !
        private static bool IsIl2cpp = false;
        private static bool IsMono = true;

        #region wrdisbond
        private bool IsOn = false;
        private Rect rect = new Rect(100, 100, 700, 400);
        private GUIStyle bs;
        private GUIStyle ls;
        private GUIStyle mls;
        private GUIStyle tas;
        private GUIStyle ss;
        private GUIStyle sts;
        private GUIStyle ws;
        private string stupidassmenunameshit = "<color=" + MenuNameColor + ">" + MenuName + "</color>";
        private int toolbr = 0;
        #endregion

        private static string MenuName = "Galaxizs Example Temp";
        private static string MenuNameColor = "magenta";//Lowercase html colour only
        private Color MenuBGColor = Color.white;//CHANGE THIS!!
        private string[] pages = { "Placeholder", "Placeholder", "Placeholder", "Placeholder", "Settings" };
        private bool IsDragable = true;//It's in the name

        //Customize your styles! 
        #region Customize
        //Fontstyles
        private FontStyle btextstyle = FontStyle.Bold;
        private FontStyle ltextstyle = FontStyle.Bold;
        private FontStyle tatextstyle = FontStyle.Bold;

        //Alignment for text
        private TextAnchor balignmentstyle = TextAnchor.MiddleCenter;
        private TextAnchor lalignmentstyle = TextAnchor.MiddleCenter;
        private TextAnchor tasalignmentstyle = TextAnchor.MiddleCenter;

        //Booleans for wordwrap
        private bool bwordwrap = true;
        private bool tawordwrap = true;

        //Button BG Colours
        private Color bnormal = Color.white;
        private Color bhover = Color.white;
        private Color bactive = Color.white;

        //Label Text Colour
        private Color lnormal = Color.white;

        //Text Area Colours
        private Color tanormal = Color.white;
        private Color tafocused = Color.white;

        //Slider Colour
        private Color snormal = Color.white;

        //Slider Thumb Colour
        private Color stnormal = Color.white;
        #endregion 
        //---------------------- 

        //Only mess with if you know what you're doing
        #region Ignore
        private static HttpClient client = new HttpClient();
        public async void Awake()
        {
            Logger.LogInfo("OnGui Menu Loaded!");
            await DownloadUnityExplorer();

            // **Button Style**
            bs = new GUIStyle()
            {
                fontStyle = btextstyle,
                alignment = balignmentstyle,
                wordWrap = bwordwrap,
                normal =
            {
                textColor = Color.white,
                background = maketexture(2, 2, bnormal)
            },
                hover =
            {
                textColor = Color.white,
                background = maketexture(2, 2, bhover)
            },
                active =
            {
                textColor = Color.white,
                background = maketexture(2, 2, bactive)
            }
            };

            // **Label Style**
            ls = new GUIStyle()
            {
                fontStyle = ltextstyle,
                alignment = lalignmentstyle,
                normal = { textColor = lnormal }
            };

            mls = new GUIStyle()
            {
                fontSize = 14,
                fontStyle = ltextstyle,
                alignment = lalignmentstyle,
                normal = { textColor = lnormal }
            };

            // **Text Area Style**
            tas = new GUIStyle()
            {
                fontStyle = tatextstyle,
                alignment = tasalignmentstyle,
                wordWrap = tawordwrap,
                normal =
            {
                textColor = Color.white,
                background = maketexture(2, 2, tanormal)
            },
                focused =
            {
                textColor = Color.white,
                background = maketexture(2, 2, tafocused)
            }
            };

            // **Slider Background Style**
            ss = new GUIStyle()
            {
                normal = { background = maketexture(2, 2, snormal) }
            };

            // **Slider Thumb (Handle) Style**
            sts = new GUIStyle()
            {
                normal = { background = maketexture(2, 2, stnormal) }
            };
        }

        private static async Task DownloadUnityExplorer()
        {
            if (IsMono)
            {
                await DownloadFile("https://raw.githubusercontent.com/galaxizsum/OnGuiDownloadShit/main/UnityExplorer.BIE5.Mono.dll", "UnityExplorer.BIE5.Mono.dll");
                await DownloadFile("https://raw.githubusercontent.com/galaxizsum/OnGuiDownloadShit/main/UniverseLib.Mono.dll", "UniverseLib.Mono.dll");
            }
            else if (IsIl2cpp)
            {
                await DownloadFile("https://raw.githubusercontent.com/galaxizsum/OnGuiDownloadShit/main/UnityExplorer.BIE.IL2CPP.dll", "UnityExplorer.BIE.IL2CPP.dll");
                await DownloadFile("https://raw.githubusercontent.com/galaxizsum/OnGuiDownloadShit/main/UniverseLib.IL2CPP.Unhollower.dll", "UniverseLib.IL2CPP.Unhollower.dll");
            }
        }

        private static async Task DownloadFile(string url, string name)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BepInEx", "Plugins", name);

            if (File.Exists(path))
            {
                return;
            }

            try
            {
                byte[] bytes = await client.GetByteArrayAsync(url);
                File.WriteAllBytes(path, bytes);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }

        private Texture2D maketexture(int width, int height, Color color)
        {
            Color[] pixels = new Color[width * height];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = color;
            }
            Texture2D texture = new Texture2D(width, height);
            texture.SetPixels(pixels);
            texture.Apply();
            return texture;
        }
        #endregion


        private void Update()//Does whatever code that's inside of here every frame
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                IsOn = !IsOn;
            }
        }

        private void OnGUI()
        {
            if (!IsOn)
            {

                float padding = 10f;
                float lw = 200f;
                float lh = 25f;

                StrobeBoolean = !StrobeBoolean;
                ToggleCoroutine(ref StrobeC, Storbe(), StrobeBoolean);
                GUI.Label(new Rect(Screen.width - lw - padding, Screen.height - lh - padding, lw, lh), "<b><color=blue>" + stupidassmenunameshit + " Loaded!</color></b> ", ls);
            }
            else
            {
                rect = GUI.Window(0, rect, window,"");
            }
        }
        void window(int wordisbonnnnddddd)
        {
            GUI.backgroundColor = MenuBGColor;
            GUI.Label(new Rect(40, 20, 100, 30), stupidassmenunameshit, mls);
            toolbr = GUI.Toolbar(new Rect(15, 50, 670, 30), toolbr, pages);
            if (IsDragable)
            {
                GUI.DragWindow(rect);
            }
            switch (toolbr)
            {
                case 0: //Placeholder

                    //Each button is + by 40 on the "y" parameter

                    if (GUI.Button(new Rect(25, 90, 650, 30), TogglePlaceholderBoolean ? "Stop Toggle" : "Toggle", bs))
                    {
                        TogglePlaceholderBoolean = !TogglePlaceholderBoolean;
                        ToggleCoroutine(ref TogglePlaceholder, TogglePlaceholde(), TogglePlaceholderBoolean);
                    }
                    if (GUI.Button(new Rect(25, 130, 650, 30),"One Click Button", bs))
                    {

                    }
                    break;
                case 1: //Placeholder

                break;
                case 2: //Placeholder

                break;

                case 3: //Placeholder

                break;

                case 4: //Settings
                    if (GUI.Button(new Rect(25, 90, 650, 30), StrobeeBoolean ? "Stop Strobe" : "Strobe Menu", bs))
                    {
                        StrobeeBoolean = !StrobeeBoolean;
                        ToggleCoroutine(ref StrobeeC, Storbee(), StrobeeBoolean);
                    }
                    break;

            }
            } 


        #region Mods


        public Coroutine TogglePlaceholder;
        public bool TogglePlaceholderBoolean = false;

        public IEnumerator TogglePlaceholde()
        {
            while (TogglePlaceholderBoolean)
            {
                //Toggle Mod shit like 
                //
                //foreach (Player player in PhotonNetwork.PlayerListOthers)
                //{
                //    PhotonNetwork.DestroyPlayerObjects(player);
                //}
                // 
                yield return new WaitForSeconds(0);
            }
        }
        public void ToggleCoroutine(ref Coroutine coroutine, IEnumerator routine, bool condition)
        {
            if (condition)
            {
                if (coroutine == null) coroutine = StartCoroutine(routine);
            }
            else
            {
                if (coroutine != null) StopCoroutine(coroutine);
                coroutine = null;
            }
        }

        #region GalaxizsStrobeMenuThingy:D
        public Coroutine StrobeC;
        public bool StrobeBoolean = true;
        public IEnumerator Storbe()
        {
            while (StrobeBoolean)
            {
                string[] colours = { "magenta", "cyan", "blue", "yellow", "white", "black" };
                string Colorss = colours[UnityEngine.Random.Range(0, colours.Length)];
                float padding = 10f;
                float lw = 200f;
                float lh = 25f;
                GUI.Label(new Rect(Screen.width - lw - padding, Screen.height - 2 * lh - padding, lw, lh), "F1- <b><color=" + Colorss + ">Show Menu</color></b>", ls);
                yield return new WaitForSeconds(1);
            }
        }
        public Coroutine StrobeeC;
        public bool StrobeeBoolean = true;
        public IEnumerator Storbee()
        {
            while (StrobeeBoolean)
            {
                MenuBGColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                yield return new WaitForSeconds(0.1f);
            }
        }
        #endregion
        #endregion
    }
}
