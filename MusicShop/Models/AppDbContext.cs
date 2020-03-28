using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Electric Guitars",
                    CategoryDescription = "Vintage and modern electric guitars"

                },

                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Electric Guitar Amplifiers",
                    CategoryDescription = "Powerful and professional electric guitar amplifiers"

                },

                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Electric Basses",
                    CategoryDescription = "4-string and 5-string electric basses"

                },

                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Bass Amplifiers",
                    CategoryDescription = "Loud and mobile electric bass amplifiers"

                }
                );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    ProductId = 8,
                    ProductName = "Fender 70th Anniversary Broadcaster",
                    ShortDescription = "Fender AM Vintage 70th Anniversary Broadcaster BGB, electric guitar, ash body, maple neck, 50s Broadcaster 'U' shape.",

                    LongDescription = "Fender AM Vintage 70th Anniversary Broadcaster BGB, electric guitar, ash body, maple neck, 50s Broadcaster 'U' shape, maple fretboard, 7.25' radius, 21x vintage tall style frets, 41,4mm bone nut, 648mm scale, 2x customshop handwound ,50-,51 blackguard single-coil pickups, Single Line 'Fender Deluxe' vintage style tuning keys, original vintage-style Tele, Bridge with 3 brass saddles, finish: Blackguard Blonde,New Fender Flash Coat Lacquer, incl vintage tweed case",

                    Price = 2199M,
                    InStock = false,
                    AmountInStock = 0,
                    ImageThumbnailUrl = "https://thumbs.static-thomann.de/thumb/thumb150x150/pics/prod/482991.jpg",
                    ImageUrl = "https://bdbo2.thomann.de/thumb/bdb2500/pics/bdbo/14778071.jpg",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 1,
                    ProductName = " Gibson Les Paul Deluxe Ebony ",
                    ShortDescription = "Gibson Les Paul Deluxe Ebony. Body: Mahogany (Swietenia macrophylla). ",
                    LongDescription = "Cream binding,Neck: Mahogany (Swietenia macrophylla),Fretboard: Rosewood (Dalbergia Latifolia)'C'shaped neck profile,22 Medium frets,2 Gibson mini humbuckers,3-Way toggle switch,2 Volume controls, 2 tone controls,Tune-o-matic bridge and aluminium stoptail,Case included,Colour: Black,Made in USA",
                    Price = 1598M,
                    InStock = true,
                    AmountInStock = 10,
                    ImageThumbnailUrl = "https://thumbs.static-thomann.de/thumb/thumb150x150/pics/prod/474509.jpg",
                    ImageUrl = "https://images.static-thomann.de/pics/prod/474509.jpg",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Marshall DSL40CR ",
                    ShortDescription = "All Tube Combo Amp for Electric Guitar",
                    LongDescription = "All Tube Combo Amp for Electric Guitar, Reissue series - authentic DSL sound Power: 40W 2 footswitchable channels with classic gain and ultra gain Assembly: 12' Celestion V Type loudspeaker Preamp tubes: 4 x ECC83 Power tubes: 2 x EL34 Independent volume and gain controls for both channels Clean and Crunch Modes in the Classic Gain Channel Lead 1 and Lead 2 modes in the Ultra Gain channel Classic sound control with bass, middle and treble Presence control Tone - shift circuit Variable resonance control Pentode - / triode switch Digital reverb independent for each channel Speaker outputs: 2 x 16 ohms, 1 x 8 ohms and 1 x 16 ohms Includes double footswitch(channel selection and reverb on / off",

                    Price = 649M,
                    InStock = false,
                    AmountInStock = 0,
                    ImageThumbnailUrl = "https://thumbs.static-thomann.de/thumb/thumb150x150/pics/prod/422013.jpg",
                    ImageUrl = "https://bdbo2.thomann.de/thumb/bdb2500/pics/bdbo/12894607.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Fender Blues Junior Lacquered Tweed",
                    ShortDescription = "The Fender Blues Junior is the bigger brother of the Junior Pro. It packs just 15 W of power, but this is absolutely sufficient for many applications.",
                    LongDescription = "The Fender Blues Junior is the bigger brother of the Junior Pro. It packs just 15 W of power, but this is absolutely sufficient for many applications. The Blues Junior offers spring reverb and a 3-band EQ, as well as gain and master volume, meaning the sound can also be quietly distorted. Of course, it sounds better when the master is open, at which point you will realise in amazement how loud 15 W can actually be. With its 12' speaker, the amp has enough pressure to fill small clubs with sound. The name says it all: the Blues Junior is an excellent amp (not only, but especially) for blues, where the guitar can be a little ",
                    Price = 633M,
                    InStock = true,
                    AmountInStock = 10,
                    ImageThumbnailUrl = "https://thumbs.static-thomann.de/thumb/thumb150x150/pics/prod/189900.jpg",
                    ImageUrl = "https://bdbo2.thomann.de/thumb/bdb2500/pics/bdbo/10203745.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Fender Duff McKagan DLX P Bass RW WPL",
                    ShortDescription = "Fender Duff McKagan DLX P Bass RW WPL, Duff McKagan (Guns'n' Roses) artist series model",
                    LongDescription = "Duff McKagan (Guns'n' Roses) artist series model Body: Alder Bolt-on neck: Maple Fretboard: Rosewood Pearloid block fretboard inlays Neck profile: Modern C Fretboard radius: 241.3 mm (9.5') Nut width: 41.3 mm (1.63') 20 Medium jumbo frets Three-layer Black / White / Black pickguard Pickup: Seymour Duncan STKJ2B Jazz Bass single coil and split coil 1 Volume control and 1 TBX Tone control 4-Saddle pure vintage 70s bridge with single groove saddles Nickel / Chrome hardware Fender '70s vintage style stamped Open-Gear tuners with Hipshot Bass Xtender 'Drop D' on the E-string Ex-factory stringing: Fender USA Bass 7250M NPS .045 - .105 Colour: White pearl, Gig bag included.",
                    Price = 1299M,
                    InStock = true,
                    AmountInStock = 10,
                    ImageThumbnailUrl = "https://thumbs.static-thomann.de/thumb/thumb150x150/pics/prod/456888.jpg",
                    ImageUrl = "https://images.static-thomann.de/pics/prod/456888.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Fender Player Series P-Bass MN BCR",
                    ShortDescription = "Fender Player Series P-Bass MN BCR, Body: Alder, Maple neck.",
                    LongDescription = "Body: Alder, Maple neck,Fretboard: Maple,Matte neck finish,20 Frets, Nut width: 41.3 mm,Scale: 864 mm,Pickups: New Player AlNiCo V Precision Split single coil,Volume knob and tone knob,Standard open gear machine heads,Ex-factory stringing: Fender 7250M .045 - .105 (article nr 142933),Colour: Buttercream.",
                    Price = 659M,
                    InStock = true,
                    AmountInStock = 10,
                    ImageThumbnailUrl = "https://thumbs.static-thomann.de/thumb/thumb150x150/pics/prod/439272.jpg",
                    ImageUrl = "https://bdbo2.thomann.de/thumb/bdb2500/pics/bdbo/13199766.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Orange OB1-300 Combo",
                    ShortDescription = "Bi-Amp Bass Combo",
                    LongDescription = "Power: 300W at 4Ω,Class A/B,Equipped with: 1x 15 Eminence neodymium speaker,Speaker Twist speaker connector,Controls: Master, bass, middle, treble, blend, drive,Balanced XLR out,Special feature: Low frequencies of the bass signal remain undistorted, mid and high frequencies are harmonically enriched with additional overtones by a separate drive circuit (controllable by Blend control),Bi-amp switchable by foot switch,Dimensions (W x H x D): 55 x 68 x 35 cm, Weight: 29.65 kg.",
                    Price = 1179M,
                    InStock = true,
                    AmountInStock = 10,
                    ImageThumbnailUrl = "https://thumbs.static-thomann.de/thumb/thumb150x150/pics/prod/380275.jpg",
                    ImageUrl = "https://bdbo2.thomann.de/thumb/bdb2500/pics/bdbo/10880172.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 7,
                    ProductName = "Ashdown Studio 12",
                    ShortDescription = "Ashdown Studio 12, Power: 100 W, Equipped with: 1x 12' Ashdown Speaker",
                    LongDescription = "Power: 100 W, Equipped with: 1x 12' Ashdown Speaker, Tube emulation, Active and passive input, 5-Band EQ, Shape switch, DI Out(XLR), Overdrive control, FX loop, Headphone output, Line in, Footswitch connection(Drive), Dimensions(W x D x H): 41.4 x 37.8 x 47.2 cm, Weight: 10.3 kg.",
                    Price = 299M,
                    InStock = false,
                    AmountInStock = 0,
                    ImageThumbnailUrl = "https://thumbs.static-thomann.de/thumb/thumb150x150/pics/prod/470477.jpg",
                    ImageUrl = "https://bdbo2.thomann.de/thumb/bdb2500/pics/bdbo/14519669.jpg",
                    CategoryId = 3
                }

                );


        }
    }
}
