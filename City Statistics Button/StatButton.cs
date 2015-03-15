using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace SystemTimeClock
{

    public class SystemTimeClock : IUserMod
    {
        public string Name
        {
            get { return "City Statistics Easy Access"; }
        }

        public string Description
        {
            get { return "Creates a button on the main UI for easier access to City Statistics"; }
        }
    }

    public class LoadingExtension : LoadingExtensionBase
    {

        /* Hi!  I commented the hell out of this, making sure it's as straightforward as I could muster.
         * 
         * This is a very basic mod.  However, the locations for most of the methods used in this will be important
         * for quite a lot of things.  UIComponent and UIView in particular contain a whole hell of a lot of important things.
         * 
         * This is over-documented to hell.  As I'm starting out, I'm trying to break things down as much as possible,
         * mostly for my own benefit.  I tend to go cross-eyed going back and forth between code.
         * 
         * Most of this mod is making the button., and I used the following method to create the button: 
         * http://www.reddit.com/r/CitiesSkylinesModding/comments/2ymwxe/example_code_using_the_colossal_ui_in_a_user_mod/
         * So don't give me credit for that, kay? Kay.
         * 
         * The three lines of code that make the mod do the important thing took forever for me to track down. ;_;
         * 
         * You're beautiful and I love you.
         */

        public override void OnLevelLoaded(LoadMode mode)
        {

            // Create the button and make it appear on the screen.
            // UIView seems to be what is used to enable whatever element should be appearing.
            // Without it, it seems like that element will never show up.

            var boxuiView = UIView.GetAView();
            var statButton = (UIButton)boxuiView.AddUIComponent(typeof(UIButton));

            // This does more stuff.  Y'know.  Stuuuuuff.

            var uiView = GameObject.FindObjectOfType<UIView>();
            if (uiView == null) return;

            //Define how big the button is!

            statButton.width = 125;
            statButton.height = 30;

            // Defines the colors and such of the button.  Fancy!
            // The color values for statButton.textColor are that blue-ish color used on the UI to show your cash and population.
            // Seemed right to also use that for my buttons.  Everything looking uniform is cool.

            statButton.normalBgSprite = "ButtonMenu";
            statButton.hoveredBgSprite = "ButtonMenuHovered";
            statButton.focusedBgSprite = "ButtonMenuFocused";
            statButton.pressedBgSprite = "ButtonMenuPressed";
            //statButton.textColor = new Color32(255, 255, 255, 255);
            statButton.textColor = new Color32(186, 217, 238, 0);
            statButton.disabledTextColor = new Color32(7, 7, 7, 255);
            statButton.hoveredTextColor = new Color32(7, 132, 255, 255);
            statButton.focusedTextColor = new Color32(255, 255, 255, 255);
            statButton.pressedTextColor = new Color32(30, 30, 44, 255);

            // .transformPosition places where the button will show up on the screen.  Vector3 uses x/y.  You can also set a Z coordinate but why would you do that here?
            // I am not terribly good at stuff like vectors, so honestly, I've just been punching in numbers until it looks right.
            // Look, I'm not here to judge.

            // BringToFront does exactly what you'd expect. It's part of the ColossalFramework.UI.UIComponent class.
            // Without it, the button would end up behind the rest of the UI.

            statButton.transformPosition = new Vector3(1.2f, -0.93f);
            statButton.BringToFront();

            // Mmhm.  You know what this does.

            statButton.text = "City Statistics";

            // Points the button towards the logic needed for the button to do stuff.

            statButton.eventClick += ButtonClick;

        }



        private void ButtonClick(UIComponent component, UIMouseEventParameter eventParam)
        {

            /* Not much here, ironically!  Most/all of the functionality for this mode more or less existed in-game.
             * You can insert any panel where "StatisticsPanel" is.  They're all contained in Assembly-CSharp.
             * 
             * Accessing whateverPanel should also allow us to add elements to these things.
             * For instance, I'm fairly confident that I could add another graph to StatisticsPanel if
             * I beat my head against it for long enough.
             * 
             * Go HOG WILD. http://imgur.com/sUK6b0m */

            UIView.library.ShowModal("StatisticsPanel");
            UIView.library.ShowModal("StatisticsPanel").BringToFront();
            SimulationManager.instance.SimulationPaused = true;
        }

    }
}

