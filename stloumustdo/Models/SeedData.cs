using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using stloumustdo.Data;
using System;
using System.Linq;


namespace stloumustdo.Models
{
    public class SeedData
    {


        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new stloumustdoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<stloumustdoContext>>()))
            {

                if (context.Restaurants.Any())
                {
                    return;   // DB has been seeded
                }

                context.Restaurants.AddRange(
                    new Restaurants
                    {
                        RestaurantName = "The Lucky Accomplice",
                        RestaurantType = "American",
                        PriceRange = "$$",
                        Neighborhood = "Fox Park",
                        ResturauntAddress = "2501 S Jefferson Ave, St. Louis, MO 63104",
                        WebsiteUrl = "https://www.theluckyaccomplice.com/"

                    },

                    new Restaurants
                    {
                        RestaurantName = "Three Sixty",
                        RestaurantType = "American",
                        PriceRange = "$$",
                        Neighborhood = "Downtown",
                        ResturauntAddress = "1 S Broadway St, St. Louis, MO 63102",
                        WebsiteUrl = "https://www.360-stl.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "Mama’s On The Hill",
                        RestaurantType = "Italian",
                        PriceRange = "$$",
                        Neighborhood = "The Hill",
                        ResturauntAddress = "2132 Edwards St, St. Louis, MO 63110",
                        WebsiteUrl = "https://www.mamasonthehill.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "Fork & Stix",
                        RestaurantType = "Northern Thai",
                        PriceRange = "$",
                        Neighborhood = "The Loop",
                        ResturauntAddress = "549 Rosedale Ave, St. Louis, MO 63112",
                        WebsiteUrl = "https://forknstix.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "Blueberry Hill",
                        RestaurantType = "American",
                        PriceRange = "$",
                        Neighborhood = "The Loop",
                        ResturauntAddress = "6504 Delmar Blvd, St. Louis, MO 63130",
                        WebsiteUrl = "https://blueberryhill.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "The Fountain On Locust",
                        RestaurantType = "American",
                        PriceRange = "$",
                        Neighborhood = "Midtown",
                        ResturauntAddress = "3037 Locust St, St. Louis, MO 63103",
                        WebsiteUrl = "https://www.fountainonlocust.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "The Blue Duck",
                        RestaurantType = "Comfort Food",
                        PriceRange = "$",
                        Neighborhood = "Maplewood",
                        ResturauntAddress = "2661 Sutton Blvd, Maplewood, MO 63143",
                        WebsiteUrl = "https://www.blueduckstl.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "Egg@midtown",
                        RestaurantType = "Brunch",
                        PriceRange = "$$",
                        Neighborhood = "Midtown",
                        ResturauntAddress = "3100 Locust St, St. Louis, MO 63103",
                        WebsiteUrl = "https://eggstl.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "Balkan Treat Box",
                        RestaurantType = "Balkan",
                        PriceRange = "$",
                        Neighborhood = "Webster Groves",
                        ResturauntAddress = "8103 Big Bend Blvd, Webster Groves, MO 63119",
                        WebsiteUrl = "http://www.balkantreatbox.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "Broadway Oyster Bar",
                        RestaurantType = "Cajun",
                        PriceRange = "$$",
                        Neighborhood = "Downtown",
                        ResturauntAddress = "736 S Broadway St, St. Louis, MO 63102",
                        WebsiteUrl = "http://www.broadwayoysterbar.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "BLK MKT Eats",
                        RestaurantType = "Sushi/Poke",
                        PriceRange = "$",
                        Neighborhood = "Midtown",
                        ResturauntAddress = "9 S Vandeventer Ave, St. Louis, MO 63108",
                        WebsiteUrl = "http://blkmkteats.com/"
                    },

                    new Restaurants
                    {
                        RestaurantName = "Akar",
                        RestaurantType = "Malaysian",
                        PriceRange = "$$$",
                        Neighborhood = "Clayton",
                        ResturauntAddress = "7641 Wydown Blvd, Clayton, MO 63105",
                        WebsiteUrl = "https://akarstl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Boogaloo",
                        RestaurantType = "Cuban/Creole/Caribbean",
                        PriceRange = "$$",
                        Neighborhood = "Maplewood",
                        ResturauntAddress = "7344 Manchester Rd, St. Louis, MO 63143",
                        WebsiteUrl = "https://boogaloostlouis.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Annie Gunn's Restaurant",
                        RestaurantType = "Steakhouse",
                        PriceRange = "$$$",
                        Neighborhood = "Chesterfield",
                        ResturauntAddress = "16806 Chesterfield Airport Rd, Chesterfield, MO 63005",
                        WebsiteUrl = "https://www.anniegunns.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Katie's Pizza & Pasta Osteria",
                        RestaurantType = "Italian",
                        PriceRange = "$$$",
                        Neighborhood = "Town and Country",
                        ResturauntAddress = "14171 Clayton Rd, Town and Country, MO 63017",
                        WebsiteUrl = "https://katiespizzaandpasta.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Basso",
                        RestaurantType = "American-Italian",
                        PriceRange = "$$",
                        Neighborhood = "Clayton",
                        ResturauntAddress = "7036 Clayton Ave, St. Louis, MO 63117",
                        WebsiteUrl = "https://www.basso-stl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Hi-Pointe Drive-In",
                        RestaurantType = "Burgers/Sandwiches",
                        PriceRange = "$",
                        Neighborhood = "Hi-Pointe",
                        ResturauntAddress = "1033 McCausland Ave, St. Louis, MO 63117",
                        WebsiteUrl = ""
                    },
                    new Restaurants
                    {
                        RestaurantName = "Sidney Street Cafe",
                        RestaurantType = "American",
                        PriceRange = "$$$",
                        Neighborhood = "Benton Park",
                        ResturauntAddress = "2000 Sidney St, St. Louis, MO 63104",
                        WebsiteUrl = "https://www.sidneystreetcafestl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Lona's Lil Eats",
                        RestaurantType = "Asian-fusion",
                        PriceRange = "$",
                        Neighborhood = "Fox Park",
                        ResturauntAddress = "2199 California Ave, St. Louis, MO 63104",
                        WebsiteUrl = "https://lonaslileats.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Citizen Kane's Steak House",
                        RestaurantType = "Steakhouse",
                        PriceRange = "$$$",
                        Neighborhood = "Kirkwood",
                        ResturauntAddress = "133 W Clinton Pl, Kirkwood, MO 63122",
                        WebsiteUrl = "https://www.citizenkanes.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Soup Dumplings STL",
                        RestaurantType = "Asian",
                        PriceRange = "$",
                        Neighborhood = "University City",
                        ResturauntAddress = "8110 Olive Blvd, St. Louis, MO 63130",
                        WebsiteUrl = "https://www.facebook.com/soupdumplingSTL/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Cafe Natasha's",
                        RestaurantType = "Persian",
                        PriceRange = "$$",
                        Neighborhood = "South Grand",
                        ResturauntAddress = " 3200 S Grand Blvd, St. Louis, MO 63118",
                        WebsiteUrl = "https://www.cafenatasha.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Nippon Tei",
                        RestaurantType = "Japanese",
                        PriceRange = "$$",
                        Neighborhood = "Manchester",
                        ResturauntAddress = "14025 Manchester Rd, Manchester, MO 63011",
                        WebsiteUrl = "https://nippon.teistl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Sheesh",
                        RestaurantType = "Turkish",
                        PriceRange = "$$",
                        Neighborhood = "South Grand",
                        ResturauntAddress = "3226 S Grand Blvd, St. Louis, MO 63118",
                        WebsiteUrl = "https://sheeshrestaurant.com/"
                    },
                    new Restaurants
                    {
                         RestaurantName = "OLIO",
                         RestaurantType = "Mediterranean",
                         PriceRange = "$$",
                         Neighborhood = "Tower Grove",
                         ResturauntAddress = "1634 Tower Grove Ave, St. Louis, MO 63110",
                         WebsiteUrl = "https://bengelina.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Zia's Restaurant and Catering",
                        RestaurantType = "Italian",
                        PriceRange = "$$",
                        Neighborhood = "The Hill",
                        ResturauntAddress = "5256 Wilson Ave, St. Louis, MO 63110",
                        WebsiteUrl = "https://www.zias.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Pappy's Smokehouse",
                        RestaurantType = "Barbeque",
                        PriceRange = "$$",
                        Neighborhood = "Midtown",
                        ResturauntAddress = "3106 Olive St, St. Louis, MO 63103",
                        WebsiteUrl = "https://www.pappyssmokehouse.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Baileys' Range",
                        RestaurantType = "Burgers",
                        PriceRange = "$",
                        Neighborhood = "Midtown",
                        ResturauntAddress = "920 Olive St, St. Louis, MO 63101",
                        WebsiteUrl = "https://www.baileysrange.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Vivola Express",
                        RestaurantType = "Sandwich",
                        PriceRange = "$",
                        Neighborhood = "Maryland Heights",
                        ResturauntAddress = "1911 Schuetz Rd, Maryland Heights, MO 63043",
                        WebsiteUrl = "https://m.facebook.com/pages/category/American-Restaurant/Vivola-Express-808944789190512/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Corner 17",
                        RestaurantType = "Chinese",
                        PriceRange = "$",
                        Neighborhood = "The Loop",
                        ResturauntAddress = "6623 Delmar Blvd, St. Louis, MO 63130",
                        WebsiteUrl = "https://corner17usa.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Louie",
                        RestaurantType = "Italian",
                        PriceRange = "$$$",
                        Neighborhood = "Clayton",
                        ResturauntAddress = "706 De Mun Ave, Clayton, MO 63105",
                        WebsiteUrl = "https://www.louiedemun.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Sasha's on Shaw",
                        RestaurantType = "Wine Bar",
                        PriceRange = "$$",
                        Neighborhood = "Shaw",
                        ResturauntAddress = "4069 Shaw Blvd, St. Louis, MO 63110",
                        WebsiteUrl = "https://www.sashaswinebar.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Russell's on Macklind",
                        RestaurantType = "American",
                        PriceRange = "$",
                        Neighborhood = "South Hampton",
                        ResturauntAddress = "5400 Murdoch Ave, St. Louis, MO 63109",
                        WebsiteUrl = "http://russellscafe.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Gioia's Deli",
                        RestaurantType = "Deli",
                        PriceRange = "$",
                        Neighborhood = "The Hill",
                        ResturauntAddress = "1934 Macklind Ave, St. Louis, MO 63110",
                        WebsiteUrl = "https://www.gioiasdeli.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Peppe's Apt 2",
                        RestaurantType = "Italian",
                        PriceRange = "$$$",
                        Neighborhood = "Kirkwood",
                        ResturauntAddress = "800 S Geyer Rd, Kirkwood, MO 63122",
                        WebsiteUrl = "http://peppesapt2.com/index.html"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Steve's Hot Dogs",
                        RestaurantType = "Hot Dogs",
                        PriceRange = "$",
                        Neighborhood = "South Grand",
                        ResturauntAddress = "3145 S Grand Blvd, St. Louis, MO 63118",
                        WebsiteUrl = "https://www.steveshotdogsstl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Meskerem Ethiopian Restaurant",
                        RestaurantType = "Ethiopian",
                        PriceRange = "$$",
                        Neighborhood = "South Grand",
                        ResturauntAddress = "3210 S Grand Blvd, St. Louis, MO 63118",
                        WebsiteUrl = "https://meskeremstl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "St. Louis Kolache",
                        RestaurantType = "Czech",
                        PriceRange = "$",
                        Neighborhood = "Clifton Heights",
                        ResturauntAddress = "5936 Southwest Ave, St. Louis, MO 63139",
                        WebsiteUrl = "https://stlkolache.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Cinder House and Bar",
                        RestaurantType = "South American",
                        PriceRange = "$$$",
                        Neighborhood = "Downtown",
                        ResturauntAddress = "999 N 2nd St, St. Louis, MO 63102",
                        WebsiteUrl = "https://www.fourseasons.com/stlouis/dining/restaurants/cinder-house/?seo=google_local_stl4_amer"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Blues City Deli",
                        RestaurantType = "Deli",
                        PriceRange = "$",
                        Neighborhood = "Benton Park",
                        ResturauntAddress = "2438 McNair Ave, St. Louis, MO 63104",
                        WebsiteUrl = "https://www.bluescitydeli.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "5 Star Burgers",
                        RestaurantType = "Burger",
                        PriceRange = "$",
                        Neighborhood = "Clayton",
                        ResturauntAddress = "8125 Maryland Ave, Clayton, MO 63105",
                        WebsiteUrl = "https://www.5starburgersstl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Cafe Mochi",
                        RestaurantType = "Sushi",
                        PriceRange = "$",
                        Neighborhood = "South Grand",
                        ResturauntAddress = "3221 S Grand Blvd #1013, St. Louis, MO 63118",
                        WebsiteUrl = "https://www.cafemochi.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Peno Soul Food",
                        RestaurantType = "Southern Italian",
                        PriceRange = "$$$",
                        Neighborhood = "Clayton",
                        ResturauntAddress = "7600 Wydown Blvd, St. Louis, MO 63105",
                        WebsiteUrl = "https://penosoulfoodstl.com/"
                    }, new Restaurants
                    {
                        RestaurantName = "Little Fox",
                        RestaurantType = "Modern Small Plates",
                        PriceRange = "$$$",
                        Neighborhood = "Fox Park",
                        ResturauntAddress = "2800 Shenandoah Ave, St. Louis, MO 63104",
                        WebsiteUrl = "https://www.littlefoxstl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Brasserie",
                        RestaurantType = "French",
                        PriceRange = "$$$",
                        Neighborhood = "Central West End",
                        ResturauntAddress = "4580 Laclede Ave, St. Louis, MO 63108",
                        WebsiteUrl = "https://brasseriebyniche.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Sanctuaria",
                        RestaurantType = "Latin American",
                        PriceRange = "$$",
                        Neighborhood = "The Grove",
                        ResturauntAddress = "4198 Manchester Ave, St. Louis, MO 63110",
                        WebsiteUrl = "https://www.sanctuariastl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "SqWires Restaurant & Market",
                        RestaurantType = "Fine Dining",
                        PriceRange = "$$$",
                        Neighborhood = "Lafayette Square",
                        ResturauntAddress = "1415 S 18th St, St. Louis, MO 63104",
                        WebsiteUrl = "https://sqwires.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Tiny Chef",
                        RestaurantType = "Korean",
                        PriceRange = "$",
                        Neighborhood = "Bevo",
                        ResturauntAddress = "4701 Morgan Ford Rd, St. Louis, MO 63116",
                        WebsiteUrl = "https://m.facebook.com/TinyChefSTL"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Frazer's Restaurant & Lounge",
                        RestaurantType = "American",
                        PriceRange = "$$",
                        Neighborhood = "Benton Park",
                        ResturauntAddress = "1811 Pestalozzi St, St. Louis, MO 63118",
                        WebsiteUrl = "https://frazersgoodeats.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Pickleman's Gourmet Cafe",
                        RestaurantType = "Sandwich",
                        PriceRange = "$",
                        Neighborhood = "Midtown",
                        ResturauntAddress = "3722 Laclede Ave, St. Louis, MO 63108",
                        WebsiteUrl = "https://www.picklemans.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Brasilia",
                        RestaurantType = "Brazilian ",
                        PriceRange = "$$",
                        Neighborhood = "South Grand",
                        ResturauntAddress = "3212 S Grand Blvd, St. Louis, MO 63118",
                        WebsiteUrl = "https://www.brasiliastl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Frisco Barroom",
                        RestaurantType = "American",
                        PriceRange = "$$",
                        Neighborhood = "Webster Groves",
                        ResturauntAddress = "8110 Big Bend Blvd, Webster Groves, MO 63119",
                        WebsiteUrl = "https://www.thefriscostl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Tai Ke Shabu Shabu",
                        RestaurantType = "Taiwanese",
                        PriceRange = "$$",
                        Neighborhood = "University City",
                        ResturauntAddress = "9626 Olive Blvd, Olivette, MO 63132",
                        WebsiteUrl = "https://www.taikeshabushabu.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Cafe Nova",
                        RestaurantType = "Mediterranean",
                        PriceRange = "$$",
                        Neighborhood = "Princeton Heights",
                        ResturauntAddress = "5611 S Kingshighway Blvd, St. Louis, MO 63109",
                        WebsiteUrl = "https://cafenovastlouis.com/11504"
                    },
                    new Restaurants
                    {
                        RestaurantName = "O'Connell's Pub",
                        RestaurantType = "Irish Pub",
                        PriceRange = "$",
                        Neighborhood = "The Hill",
                        ResturauntAddress = "4652 Shaw Ave, St. Louis, MO 63110",
                        WebsiteUrl = "https://www.oconnells-pub.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Pho Long Restaurant ",
                        RestaurantType = "Vietnamese",
                        PriceRange = "$",
                        Neighborhood = "Shaw",
                        ResturauntAddress = "2245 S Grand Blvd, St. Louis, MO 63104",
                        WebsiteUrl = "https://pholongstl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "The Golden Hoosier",
                        RestaurantType = "American",
                        PriceRange = "$$",
                        Neighborhood = "North Hampton",
                        ResturauntAddress = "3707 S Kingshighway Blvd, St. Louis, MO 63109",
                        WebsiteUrl = "https://www.thegoldenhoosier.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Krab Kingz Seafood",
                        RestaurantType = "Seafood",
                        PriceRange = "$$",
                        Neighborhood = "Marlborough",
                        ResturauntAddress = "7740 Watson Rd, St. Louis, MO 63119",
                        WebsiteUrl = "https://www.krabkingzstl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "El Burro Loco",
                        RestaurantType = "Mexican",
                        PriceRange = "$$",
                        Neighborhood = "Central West End",
                        ResturauntAddress = "313 N Euclid Ave, St. Louis, MO 63108",
                        WebsiteUrl = "https://elburroloco.net/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "The Gramophone",
                        RestaurantType = "Sandwich",
                        PriceRange = "$",
                        Neighborhood = "The Grove",
                        ResturauntAddress = "4243 Manchester Ave, St. Louis, MO 63110",
                        WebsiteUrl = "https://www.gramophonestl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "The Crossing",
                        RestaurantType = "Fine Dining",
                        PriceRange = "$$$",
                        Neighborhood = "Clayton",
                        ResturauntAddress = "7823 Forsyth Blvd, Clayton, MO 63105",
                        WebsiteUrl = "https://thecrossing-stl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Hodak's",
                        RestaurantType = "Fried Chicken",
                        PriceRange = "$",
                        Neighborhood = "Mckinley Heights",
                        ResturauntAddress = "2100 Gravois Ave, St. Louis, MO 63104",
                        WebsiteUrl = "https://www.hodaks.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Loaded Elevated Nachos",
                        RestaurantType = "Nachos",
                        PriceRange = "$",
                        Neighborhood = "St. Charles",
                        ResturauntAddress = "1450 Beale St #130, St Charles, MO 63303",
                        WebsiteUrl = "https://www.loadednachos.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "The Shaved Duck Smokehouse",
                        RestaurantType = "Barbeque",
                        PriceRange = "$$",
                        Neighborhood = "Tower Grove East",
                        ResturauntAddress = "2900 Virginia Ave, St. Louis, MO 63118",
                        WebsiteUrl = "https://www.theshavedduck.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Half & Half",
                        RestaurantType = "Brunch",
                        PriceRange = "$$",
                        Neighborhood = "Clayton",
                        ResturauntAddress = "8135 Maryland Ave, St. Louis, MO 63105",
                        WebsiteUrl = "https://www.halfandhalfstl.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Grace Meat + Three",
                        RestaurantType = "Southern",
                        PriceRange = "$$",
                        Neighborhood = "The Grove",
                        ResturauntAddress = "4270 Manchester Ave, St. Louis, MO 63110",
                        WebsiteUrl = "https://www.stlgrace.com/"
                    },
                    new Restaurants
                    {
                        RestaurantName = "Peacock Diner",
                        RestaurantType = "American",
                        PriceRange = "$",
                        Neighborhood = "The Loop",
                        ResturauntAddress = "6261 Delmar Blvd, University City, MO 63130",
                        WebsiteUrl = "https://peacockloopdiner.com/"
                    }

            );

                if (context.Cafes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cafes.AddRange(
                    new Cafe
                    {
                        CafeName = "Coma Coffee Roasters",
                        Neighborhood = "Richmond Heights",
                        Address = "1034 S Brentwood Blvd, Richmond Heights, MO 63117",
                        WebsiteUrl = "https://www.comacoffee.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Nathaniel Reid Bakery",
                        Neighborhood = "Kirkwood",
                        Address = "11243 Manchester Rd, Kirkwood, MO 63122",
                        WebsiteUrl = "https://www.nrbakery.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Mauhaus Cat Cafe",
                        Neighborhood = "Maplewood",
                        Address = "3101 Sutton Blvd, Maplewood, MO 63143",
                        WebsiteUrl = "https://mauhauscafe.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Have A Cow Cattle Co.",
                        Neighborhood = "Lafayette Square",
                        Address = "2742 Lafayette Ave, St. Louis, MO 63104",
                        WebsiteUrl = "https://www.haveacow.farm/urban-farm-store"

                    },
                     new Cafe
                    {
                        CafeName = "Clementine's Naughty & Nice Creamery",
                        Neighborhood = "South Hampton, Clayton, Lafayette Square, Town and Country, Kirkwood",
                        Address = "4715 Macklind Ave, St. Louis, MO 63109",
                        WebsiteUrl = "https://www.clementinescreamery.com/"

                     },
                    new Cafe
                    {
                        CafeName = "Sweetwaters Coffee & Tea ",
                        Neighborhood = "The Grove",
                        Address = "4071 Chouteau Ave, St. Louis, MO 63110",
                        WebsiteUrl = "https://www.sweetwaterscafe.com/st-louis-mo-the-grove/"

                    },
                    new Cafe
                    {
                        CafeName = "Living Room Coffee & Kitchen",
                        Neighborhood = "Maplewood",
                        Address = "2810 Sutton Blvd, Maplewood, MO 63143",
                        WebsiteUrl = "http://www.livingroomstl.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Shaw's Coffee",
                        Neighborhood = "The Hill",
                        Address = "5147 Shaw Ave #3039, St. Louis, MO 63110",
                        WebsiteUrl = "https://shawscoffee.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Rise Coffee",
                        Neighborhood = "The Grove",
                        Address = "4176 Manchester Ave, St. Louis, MO 63110",
                        WebsiteUrl = "https://risecoffeestl.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Blueprint Coffee",
                        Neighborhood = "The Loop",
                        Address = "6225 Delmar Blvd, St. Louis, MO 63130",
                        WebsiteUrl = "https://blueprintcoffee.com/"

                    },
                    new Cafe
                    {
                        CafeName = "The Mud House",
                        Neighborhood = "Benton Park",
                        Address = "2101 Cherokee St, St. Louis, MO 63118",
                        WebsiteUrl = "http://www.themudhousestl.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Sump Coffee",
                        Neighborhood = "Marine Villa",
                        Address = "3700 S Jefferson Ave, St. Louis, MO 63118",
                        WebsiteUrl = "https://www.sumpcoffee.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Coffeestamp",
                        Neighborhood = "Benton Park",
                        Address = "2511 S Jefferson Ave, St. Louis, MO 63104",
                        WebsiteUrl = "https://www.coffeestamp.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Mauki's Bakery & Country Store",
                        Neighborhood = "Soulard",
                        Address = "1730 S 8th St, St. Louis, MO 63104",
                        WebsiteUrl = "https://www.maukisbakery.com/home"

                    },
                    new Cafe
                    {
                        CafeName = "MoKaBe's Coffeehouse",
                        Neighborhood = "Tower Grove",
                        Address = "3606 Arsenal St, St. Louis, MO 63116",
                        WebsiteUrl = "https://www.mokabescoffeehouse.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Protagonist Cafe",
                        Neighborhood = "Soulard",
                        Address = "1700 S 9th St, St. Louis, MO 63104",
                        WebsiteUrl = "https://www.protagonistcafe.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Hartford Coffee Company",
                        Neighborhood = "Tower Grove",
                        Address = "3974 Hartford St, St. Louis, MO 63116",
                        WebsiteUrl = "https://hartfordcoffee.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Pipers Tea & Coffee",
                        Neighborhood = "North Hampton",
                        Address = "3701 S Kingshighway Blvd, St. Louis, MO 63109",
                        WebsiteUrl = "https://www.cupofpipers.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Maypop Coffee & Garden Shop",
                        Neighborhood = "Webster Groves",
                        Address = "803 Marshall Ave, Webster Groves, MO 63119",
                        WebsiteUrl = "https://www.maypopshop.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Companion-Ladue",
                        Neighborhood = "Ladue",
                        Address = "9781 Clayton Rd, St. Louis, MO 63124",
                        WebsiteUrl = "https://www.companionbaking.com/cafes/"

                    },
                    new Cafe
                    {
                        CafeName = "Espresso Yourself Coffee & Cafe",
                        Neighborhood = "South Hampton",
                        Address = "5351 Devonshire Ave, St. Louis, MO 63109",
                        WebsiteUrl = "https://espressoyourselfcafe.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Seedz Provisions",
                        Neighborhood = "Clayton",
                        Address = "6350 S Rosebury Ave, St. Louis, MO 63105",
                        WebsiteUrl = "https://seedzcafe.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Oliver’s Coffee And Flower Bar",
                        Neighborhood = "Maplewood",
                        Address = "7401 Hazel Ave, Maplewood, MO 63143",
                        WebsiteUrl = "https://www.oliverscf.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Sweet Em’s Coffee & Ice Cream",
                        Neighborhood = "Clayton-Tamm",
                        Address = "6330 Clayton Ave, St. Louis, MO 63139",
                        WebsiteUrl = "https://sweetems-enterprise.square.site/"

                    },
                    new Cafe
                    {
                        CafeName = "Northwest Coffee Roasting",
                        Neighborhood = "Central West End",
                        Address = "4251 Laclede Ave, St. Louis, MO 63108",
                        WebsiteUrl = "http://www.northwestcoffee.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Cursed Bikes & Coffee",
                        Neighborhood = "University City",
                        Address = "7401 Pershing Ave, University City, MO 63130",
                        WebsiteUrl = "https://cursedbikesandcoffee.com/"

                    },
                    new Cafe
                    {
                        CafeName = "City Coffee & Creperie",
                        Neighborhood = "Clayton",
                        Address = "36 N Brentwood Blvd, Clayton, MO 63105",
                        WebsiteUrl = "http://www.citycoffeeandcreperie.com/"

                    },
                    new Cafe
                    {
                        CafeName = "The Daily Bread Bakery & Cafe",
                        Neighborhood = "Des Pres",
                        Address = "11719 Manchester Rd, St. Louis, MO 63131",
                        WebsiteUrl = "https://www.thedbcafe.com/"

                    },
                    new Cafe
                    {
                        CafeName = "The Annex Coffee and Foods",
                        Neighborhood = "Webster Groves",
                        Address = "8122 Big Bend Blvd, Webster Groves, MO 63119",
                        WebsiteUrl = "http://theannexstl.com/"
                    },
                    new Cafe
                    {
                        CafeName = "Vincent Van Doughnut",
                        Neighborhood = "The Grove",
                        Address = "1072 Tower Grove Ave, St. Louis, MO 63110",
                        WebsiteUrl = "https://vincentvandoughnut.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Ursa Minor Coffee",
                        Neighborhood = "North Hampton",
                        Address = "5760 Chippewa St, St. Louis, MO 63109",
                        WebsiteUrl = "http://www.ursaminor.coffee/"

                    },
                    new Cafe
                    {
                        CafeName = "Latté Lounge + HG Eatery",
                        Neighborhood = "Midtown",
                        Address = "2617 Washington Ave Suite A, St. Louis, MO 63103",
                        WebsiteUrl = "https://llhgstl.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Strange Donuts",
                        Neighborhood = "Maplewood",
                        Address = "2709 Sutton Blvd, Maplewood, MO 63143",
                        WebsiteUrl = "https://www.strangedonuts.com/"

                    },
                    new Cafe
                    {
                        CafeName = "Tower Grove Creamery",
                        Neighborhood = "Tower Grove",
                        Address = "3101 S Grand Blvd, St. Louis, MO 63118",
                        WebsiteUrl = "https://www.facebook.com/towergrovecreamery/"

                    },
                    new Cafe
                    {
                        CafeName = "World's Fair Donuts",
                        Neighborhood = "",
                        Address = "1904 S Vandeventer Ave, St. Louis, MO 63110",
                        WebsiteUrl = "http://places.singleplatform.com/worlds-fair-donuts/menu?ref=google"

                    },
                    new Cafe
                    {
                        CafeName = "Donut Drive In",
                        Neighborhood = "Lindenwood Park",
                        Address = "6525 Chippewa St, St. Louis, MO 63109",
                        WebsiteUrl = "https://donutdrivein.com/"
                    }
                );

                if (context.LocalAttractions.Any())
                {
                    return;   // DB has been seeded
                }

                context.LocalAttractions.AddRange(
                    new LocalAttraction
                    {
                        AttractionName = "City Museum",
                        Neighborhood = "Downtown",
                        Address = "750 N 16th St, St. Louis, MO 63103",
                        AttractionUrl = "https://www.citymuseum.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "The Gateway Arch",
                        Neighborhood = "Downtown",
                        Address = "11 North 4th Street, St. Louis, MO 63102",
                        AttractionUrl = "https://www.gatewayarch.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "The Wheel",
                        Neighborhood = "Downtown",
                        Address = "1820 Market Street, St. Louis, MO 63103",
                        AttractionUrl = "https://www.thestlouiswheel.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Laumeier Sculpture Park",
                        Neighborhood = "Sappington",
                        Address = "12580 Rott Rd, Sappington, MO 63127",
                        AttractionUrl = "https://www.laumeiersculpturepark.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Kitchen Conservatory Cooking Class",
                        Neighborhood = "Clayton",
                        Address = "8021 Clayton Rd, St. Louis, MO 63117",
                        AttractionUrl = "https://www.kitchenconservatory.com/Cooking-Classes.aspx"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Miniature Museum",
                        Neighborhood = "Bevo",
                        Address = "4746 Gravois Ave, St. Louis, MO 63116",
                        AttractionUrl = "https://www.miniaturemuseum.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Missouri Botanical Garden",
                        Neighborhood = "Tower Grove Park",
                        Address = "4344 Shaw Blvd, St. Louis, MO 63110",
                        AttractionUrl = "https://www.missouribotanicalgarden.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Saint Louis Science Center",
                        Neighborhood = "Forest Park Southeast",
                        Address = "5050 Oakland Ave, St. Louis, MO 63110",
                        AttractionUrl = "https://www.slsc.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Saint Louis Art Museum",
                        Neighborhood = "Forest Park",
                        Address = "1 Fine Arts Dr, St. Louis, MO 63110",
                        AttractionUrl = "https://www.slam.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Aquarium at Union Station",
                        Neighborhood = "Downtown",
                        Address = "201 S 18th St, St. Louis, MO 63103",
                        AttractionUrl = "https://www.stlouisaquarium.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Anheuser-Busch St. Louis Brewery",
                        Neighborhood = "Benton Park",
                        Address = "1200 Lynch St, St. Louis, MO 63118",
                        AttractionUrl = "https://www.anheuser-busch.com/about/breweries-and-tours/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Missouri History Museum",
                        Neighborhood = "Forest Park",
                        Address = "5700 Lindell Blvd, St. Louis, MO 63112",
                        AttractionUrl = "https://mohistory.org/museum"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Citygarden Sculpture Park",
                        Neighborhood = "Downtown",
                        Address = "801 Market St, St. Louis, MO 63101",
                        AttractionUrl = "http://www.citygardenstl.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Saint Louis Zoo",
                        Neighborhood = "Forest Park",
                        Address = "1 Government Dr, St. Louis, MO 63110",
                        AttractionUrl = "https://www.stlzoo.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "The Moto Museum",
                        Neighborhood = "Midtown",
                        Address = "3441 Olive St, St. Louis, MO 63103",
                        AttractionUrl = "https://www.themotomuseum.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "The Boom Boom Room",
                        Neighborhood = "Downtown",
                        Address = "1229 Washington Ave, St. Louis, MO 63103",
                        AttractionUrl = "https://www.theboomboomroomstl.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "The Muny",
                        Neighborhood = "Forest Park",
                        Address = "1 Theatre Dr, St. Louis, MO 63112",
                        AttractionUrl = "https://muny.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Soulard Farmers Market",
                        Neighborhood = "Soulard",
                        Address = "730 Carroll St, St. Louis, MO 63104",
                        AttractionUrl = "https://www.facebook.com/SoulardMarket/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Steinberg Skating Rink",
                        Neighborhood = "Forest Park",
                        Address = "400 Jefferson Dr, St. Louis, MO 63110",
                        AttractionUrl = "https://www.steinbergrink.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "The Magic House",
                        Neighborhood = "Kirkwood",
                        Address = "516 S Kirkwood Rd, St. Louis, MO 63122",
                        AttractionUrl = "https://www.magichouse.org/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Six Flags St. Louis",
                        Neighborhood = "Eureka",
                        Address = "4900 Six Flags Rd, Eureka, MO 63025",
                        AttractionUrl = "https://www.sixflags.com/stlouis"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Gateway Arch Riverboats",
                        Neighborhood = "Downtown",
                        Address = "50 S Leonor K Sullivan Blvd, St. Louis, MO 63102",
                        AttractionUrl = "https://www.gatewayarch.com/experience/riverboat-cruises/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "The Pageant",
                        Neighborhood = "The Loop",
                        Address = "6161 Delmar Blvd, St. Louis, MO 63112",
                        AttractionUrl = "https://www.thepageant.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "The Fabulous Fox",
                        Neighborhood = "Midtown",
                        Address = "527 N Grand Blvd, St. Louis, MO 63103",
                        AttractionUrl = "https://www.fabulousfox.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "FanDuel Sportsbook and Horse Racing",
                        Neighborhood = "Collinsville, IL",
                        Address = "9301 Collinsville Rd, Collinsville, IL 62234",
                        AttractionUrl = "http://fairmountpark.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Skyview Drive-In",
                        Neighborhood = "Belleville, IL ",
                        Address = "5700 N Belt W, Belleville, IL 62226",
                        AttractionUrl = "http://www.skyview-drive-in.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "World Wide Technology Raceway",
                        Neighborhood = "Madison, IL ",
                        Address = "700 Raceway Blvd, Madison, IL 62060",
                        AttractionUrl = "https://wwtraceway.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Helium Comedy Club",
                        Neighborhood = "Richmond Heights",
                        Address = "1151 St Louis Galleria St, Richmond Heights, MO 63117",
                        AttractionUrl = "https://st-louis.heliumcomedy.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Club Viva Salsa Lessons",
                        Neighborhood = "Central West End",
                        Address = "408 N Euclid Ave, St. Louis, MO 63108",
                        AttractionUrl = "https://www.clubvivastl.com/dance-lessons-1"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Yoga Trapeze STL",
                        Neighborhood = "Botanical Heights",
                        Address = "3965 Park Ave fl 2, St. Louis, MO 63110",
                        AttractionUrl = "https://www.facebook.com/yogatrapezestl/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "FLOAT STL",
                        Neighborhood = "Midtown",
                        Address = "3027 Locust St, St. Louis, MO 63108",
                        AttractionUrl = "https://www.floatingstl.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Third Degree Glass Factory Glass Blowing Lesson",
                        Neighborhood = "Central West End",
                        Address = "5200 Delmar Blvd, St. Louis, MO 63108",
                        AttractionUrl = "https://thirddegreeglassfactory.com/glassblowing/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "StilL 630 Distillery Tour 21+",
                        Neighborhood = "Downtown",
                        Address = "1000 S 4th St, St. Louis, MO 63104",
                        AttractionUrl = "https://www.still630.com/pages/tours"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Mixology Class with Intoxicology",
                        Neighborhood = "The Grove",
                        Address = "4321 Manchester Ave, St. Louis, MO 63110",
                        AttractionUrl = "https://www.intoxicologystl.com/hands-on-workshop2"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "Pieces Board Game Bar And Restaurant",
                        Neighborhood = "Soulard",
                        Address = "1535 S 8th St, St. Louis, MO 63104",
                        AttractionUrl = "https://www.stlpieces.com/"

                    },

                    new LocalAttraction
                    {
                        AttractionName = "W Karaoke Lounge",
                        Neighborhood = "The Loop",
                        Address = "6655 Delmar Blvd, University City, MO 63130",
                        AttractionUrl = "https://www.thewkaraoke.com/"

                    }
                );

                if (context.StatewideOutdoors.Any())
                {
                    return;   // DB has been seeded
                }

                context.StatewideOutdoors.AddRange(
                    new StatewideOutdoors
                    {
                        OutdoorName = "Lone Elk Park",
                        DistanceFromSTL = "30 Minutes",
                        Address = "1 Lone Elk Park Rd, Valley Park, MO 63088",
                        OutdoorUrl = "https://stlouiscountymo.gov/st-louis-county-departments/parks/places/lone-elk-park/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Weldon Spring Lewis & Clark Hiking Trail",
                        DistanceFromSTL = "40 Minutes",
                        Address = "7394-7398 MO-94, St Charles, MO 63304",
                        OutdoorUrl = "https://www.alltrails.com/trail/us/missouri/lewis-and-clark-trail-and-lewis-trail-loop"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Johnson's Shut-Ins State Park",
                        DistanceFromSTL = "2 hours",
                        Address = "148 Taum Sauk Trail, Middle Rrook, MO 63656",
                        OutdoorUrl = "https://mostateparks.com/park/johnsons-shut-ins-state-park"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Onondaga Cave State Park",
                        DistanceFromSTL = "1.5 Hours",
                        Address = "7556 Hwy H, Leasburg, MO 65535",
                        OutdoorUrl = "https://mostateparks.com/park/onondaga-cave-state-park"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Lake of the Ozarks",
                        DistanceFromSTL = "3 Hours",
                        Address = "",
                        OutdoorUrl = "https://www.funlake.com/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Bonne Terre Mine Dive ",
                        DistanceFromSTL = "1 Hour",
                        Address = "185 Park Ave, Bonne Terre, MO 63628",
                        OutdoorUrl = "https://www.bonneterremine.com/diving"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Endangered Wolf Center",
                        DistanceFromSTL = "30 Minutes",
                        Address = "6750 Tyson Valley Rd, Eureka, MO 63025",
                        OutdoorUrl = "https://www.endangeredwolfcenter.org/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Crystal City Underground Kayaking",
                        DistanceFromSTL = "45 Minutes",
                        Address = "700 Crystal Ave, Crystal City, MO 63019",
                        OutdoorUrl = "https://crystalcityunderground.com/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Meramec Caverns",
                        DistanceFromSTL = "1.25 Hours",
                        Address = "1135 Hwy W, Sullivan, MO 63080",
                        OutdoorUrl = "https://www.americascave.com/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Ha Ha Tonka Castle Ruins",
                        DistanceFromSTL = "3 Hours",
                        Address = "Natural Bridge Rd, Camdenton, MO 65020",
                        OutdoorUrl = "https://mostateparks.com/park/ha-ha-tonka-state-park"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Hermann Wine Trail",
                        DistanceFromSTL = "1.5 Hours",
                        Address = "150A Market St, Hermann, MO 65041",
                        OutdoorUrl = "https://hermannwinetrail.com/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Fort Osage National Historic Landmark",
                        DistanceFromSTL = "4 Hours",
                        Address = "105 Osage St, Sibley, MO 64088",
                        OutdoorUrl = "https://fortosagenhs.com/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Echo Bluff State Park",
                        DistanceFromSTL = "3 Hours",
                        Address = "34489 Echo Bluff Drive, Eminence, MO 65466",
                        OutdoorUrl = "https://echobluffstatepark.com/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Bucks and Spurs Guest Ranch",
                        DistanceFromSTL = "4 Hours",
                        Address = "HC 71 Box 163, Douglas County Fm Rd A422, Ava, MO 65608",
                        OutdoorUrl = "https://www.duderanch.com/missouri/bucks-spurs-guest-ranch/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "The Pinnacles Hike",
                        DistanceFromSTL = "2.5 Hours",
                        Address = "850 E Pinnacles Rd, Sturgeon, MO 65284",
                        OutdoorUrl = "https://www.atlasobscura.com/places/the-pinnacles-2-sturgeon-missouri"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Chandler Hill Vineyards",
                        DistanceFromSTL = "45 Minutes",
                        Address = "596 Defiance Rd, Defiance, MO 63341",
                        OutdoorUrl = "https://www.chandlerhillvineyards.com/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Blue Spring",
                        DistanceFromSTL = "2.45 Hours",
                        Address = "County Rd 535, Ellington, MO 63638",
                        OutdoorUrl = "https://www.nps.gov/ozar/blue-spring.htm"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "The Fugitive Beach",
                        DistanceFromSTL = "2 Hours",
                        Address = "16875 County Rd 5285, Rolla, MO 65401",
                        OutdoorUrl = "https://www.fugitive-beach.com/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Mina Sauk Falls Hike",
                        DistanceFromSTL = "2 Hours",
                        Address = "Taum Sauk State Park,, Ironton, MO 63650",
                        OutdoorUrl = "https://www.alltrails.com/trail/us/missouri/mina-saulk-falls-trail"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Dogwood Canyon Nature Park",
                        DistanceFromSTL = "5 Hours",
                        Address = "2038 State Hwy 86, Lampe, MO 65681",
                        OutdoorUrl = "https://dogwoodcanyon.org/"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Inspiration Point - Illinois",
                        DistanceFromSTL = "2 Hours",
                        Address = "Larue Rd, Wolf Lake, IL 62998",
                        OutdoorUrl = "https://www.alltrails.com/trail/us/illinois/inspiration-point-trail-shawnee-national-forest"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Elephant Rocks State Park",
                        DistanceFromSTL = "1.5 Hours",
                        Address = "7406 Highway 21, Belleview,MO 63623",
                        OutdoorUrl = "https://mostateparks.com/park/elephant-rocks-state-park"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Klondike Park",
                        DistanceFromSTL = "50 Minutes",
                        Address = "4600 S Missouri 94, Augusta, MO 63332",
                        OutdoorUrl = "https://www.sccmo.org/690/Klondike-Park"

                    },
                    new StatewideOutdoors
                    {
                        OutdoorName = "Garden of the Gods",
                        DistanceFromSTL = "3 Hours",
                        Address = "Picnic Rd, Herod, IL 62947",
                        OutdoorUrl = "https://www.fs.usda.gov/recarea/shawnee/recreation/hiking/recarea/?recid=10685&actid=51"

                    }
             );




                context.SaveChanges();
            }     
        }
    }
}
