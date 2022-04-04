using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Clickables
{
    public abstract class IClickable
    {
        public bool canBeClicked;


        public IClickable(bool clickable = true)
        {
            canBeClicked = clickable;
        }

        public bool OnClick()
        {
            if (!canBeClicked)
                return false;
            ClickEvent();
            return true;
        }

        public virtual void ClickEvent()
        {

        }
    }
}