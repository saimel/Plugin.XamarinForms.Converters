// MainPageViewModel.cs
//
// Author: Saimel Saez <saimelsaez@gmail.com>
//
// 8/12/2019
//
// --------------------------------------------------

using System.ComponentModel;

namespace Demo.Enums
{
    public enum EventType
    {
        None,
        Movie,
        Concert,
        Sports,
        [Description("City Tour")]
        CityTour
    }
}
