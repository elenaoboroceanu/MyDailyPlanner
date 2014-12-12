using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;

using DailyPlanner.Dal.DbContexts;
using DailyPlanner.DomainClasses;
using DailyPlanner.DomainClasses.Utilities;

namespace DailyPlanner.Dal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DailyPlanner.Dal.DbContexts.DailyPlannerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DailyPlanner.Models.DailyPlannerDbContext";
      
        }

        protected override void Seed(DailyPlanner.Dal.DbContexts.DailyPlannerDbContext context)
        {
            PopulateDatabase(context);
        }
         private static void PopulateDatabase(DailyPlannerDbContext context)
        {
            var eating = new ActivityType {Name = "Eating"};
            var nightSleep = new ActivityType {Name = "Night time sleep"};
            var bathActivityType = new ActivityType {Name = "Bathing"};
            var nap = new ActivityType {Name = "Taking a nap"};
            var structuredActivity = new ActivityType {Name = "Structured Activities"};
            

            context.ActivityTypes.AddOrUpdate(
                p => p.Name,
                eating,
                nightSleep,
                bathActivityType,
                nap,
                structuredActivity,
                new ActivityType {Name = "Other activities of daily living-eg. nappy changing"},                
                new ActivityType {Name = "Leisure time"},
                new ActivityType {Name = "Travel"},
                new ActivityType {Name = "Unstructured down time"},                            
                new ActivityType {Name = "Pre-school"}
                );

           
            var personalToy = new ToyType {Name = "Personal toy"};
            var borrowedToy = new ToyType { Name = "Borrowed toy" };
            context.ToyTypes.AddOrUpdate(
                p => p.Name,
                borrowedToy,           
                personalToy
                );

            var bedroom = new FlashcardType {Name = "Bedroom", Description = "Images from bedroom"};
            var bathroom = new FlashcardType {Name = "Bathroom"};
            var kitchen = new FlashcardType {Name = "Kitchen"};
            context.FlashcardTypes.AddOrUpdate(
                p => p.Name,
                bedroom,
                bathroom,
                kitchen,
                new FlashcardType {Name = "Livingroom"},
                new FlashcardType {Name = "The dinner table"},
                new FlashcardType {Name = "Outdoors-the house"},
                new FlashcardType {Name = "Outdoors-nearby the house"},
                new FlashcardType {Name = "Playground"},
                new FlashcardType {Name = "The pre-school"},
                new FlashcardType {Name = "The desk"}
                );
            //"Toilet, shower, toothbrush, mirror, sink, tap, towel, bath, toothpaste, soap"
            var toilet = new Flashcard()
            {
                Name = "Toilet",
                Description = "Toilet",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };
            var shower = new Flashcard()
            {
                Name = "Shower",
                Description = "Shower",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };
            var toothbrush = new Flashcard()
            {
                Name = "Toothbrush",
                Description = "Toothbrush",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };
            var mirror = new Flashcard()
            {
                Name = "Mirror",
                Description = "Mirror",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };
            var sink = new Flashcard()
            {
                Name = "Sink",
                Description = "Sink",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };
            var tap = new Flashcard()
            {
                Name = "Tap",
                Description = "Tap",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };
            var towel = new Flashcard()
            {
                Name = "Towel",
                Description = "Towel",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };
            var bath = new Flashcard()
            {
                Name = "Bath",
                Description = "Bath",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };
            var toothpaste = new Flashcard()
            {
                Name = "Toothpaste",
                Description = "Toothpaste",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };
            var soap = new Flashcard()
            {
                Name = "Soap",
                Description = "Soap",
                Type = bathroom,
                FlashcardTypeId = bathroom.Id,
                Image = null
            };

            context.Flashcards.AddOrUpdate(p => p.Name, toilet, shower, toothbrush, mirror, sink, tap, towel, bath,
                toothpaste, soap);

            var drawingBook = new Toy
            {
                Name = "Drawing book",
                Description = "Different drawing books",
                ToyType = personalToy,
                ToyTypeId = personalToy.Id
            };
            var playDough = new Toy
            {
                Name = "Play dough",
                Description = "Dough to play",
                ToyType = personalToy,
                ToyTypeId = personalToy.Id
            };
            var riceInCups = new Toy
            {
                Name = "Rice in cups",
                ToyType = personalToy,
                ToyTypeId = personalToy.Id
            };
            var ringsOnSticks = new Toy
            {
                Name = "Color match: rings on sticks",
                Description = "He has to match colors on sticks",
                ToyType = borrowedToy,
                ToyTypeId = borrowedToy.Id
            };
            var carsOnWhireToy = new Toy
            {
                Name = "Threading: cars on a wire",
                Description = "Put cars on whire",
                ToyType = borrowedToy,
                ToyTypeId = borrowedToy.Id
            };
            var paintBrush = new Toy
            {
                Name = "Paintbrush",
                Description = "",
                ToyType = personalToy,
                ToyTypeId = personalToy.Id
            };

            context.Toys.AddOrUpdate(
                p => p.Name,
                drawingBook,
                playDough,
                ringsOnSticks,
                riceInCups,
                carsOnWhireToy,
                new Toy
                {
                    Name = "Bowling",
                    Description = "Bowling set",
                    ToyType = borrowedToy,
                    ToyTypeId = borrowedToy.Id
                },
               
                new Toy
                {
                    Name = "Shape match: cars on wooden table",
                    Description = "Put cars on the same shape in a wooden table",
                    ToyType = personalToy,
                    ToyTypeId = personalToy.Id
                },
                new Toy
                {
                    Name = "Shape match: geometrical shapes on wooden table",
                    ToyType = personalToy,
                    ToyTypeId = personalToy.Id
                }
                );
            var eatingBreakfastActivity = new Activity()
            {
                Name = "Eating breakfast",
                Description = "Eating breakfast in the morning",
                ActivityTypeId = eating.Id,
                ActivityType = eating,
                Flashcards = new Collection<Flashcard>(),
                Toys = new Collection<Toy>()
            };
            var threadingActivity = new Activity()
            {
                Name = "Puting cars on whire",
                Description = "Cars on whire",
                ActivityType = structuredActivity,
                ActivityTypeId = structuredActivity.Id,
                Flashcards = new Collection<Flashcard>(),
                Toys = new Collection<Toy>() {carsOnWhireToy}
            };
            var painting = new Activity()
            {
                Name = "Painting",
                Description = "",
                ActivityType = structuredActivity,
                ActivityTypeId = structuredActivity.Id,
                Flashcards = new Collection<Flashcard>(),
                Toys = new Collection<Toy>() { paintBrush }
            };


            var flashcardsBathActivity = new Activity()
            {
                Name = "10 flashcards related to bathroom",
                Description = "Toilet, shower, toothbrush, mirror, sink, tap, towel, bath, toothpaste, soap",
                ActivityType = structuredActivity,
                ActivityTypeId = structuredActivity.Id,
                Flashcards =
                    new Collection<Flashcard>()
                    {
                        toilet,
                        shower,
                        toothbrush,
                        mirror,
                        sink,
                        tap,
                        towel,
                        bath,
                        toothpaste,
                        soap
                    },
                Toys = new Collection<Toy>()
            };

            context.Activities.AddOrUpdate(p => p.Name,
                eatingBreakfastActivity,
                threadingActivity,
                flashcardsBathActivity,
                painting);

             var smecta = new Pill()
             {
                 Name = "Smecta",
                 Quantity = 1,
                 Days = 4,
                 UnitOfMeasure = UnitOfMeasure.Sachet,
                 Comment =
                     "When he has diarrhea, give two sachets in the first day and then one sachet every day for 3 days."
             };
             var enterol = new Pill()
             {
                 Name = "Enterol",
                 Quantity = 1,
                 Days = 10,
                 UnitOfMeasure = UnitOfMeasure.Pill,
                 Comment = "When he has diarrhea, give one pill per day for 10 days."
             };
             var paracetamol = new Pill()
             {
                 Name = "Paracetamol",
                 Quantity = 4,
                 Days = 5,
                 UnitOfMeasure = UnitOfMeasure.Mills,
                 Comment =
                     "When he has fever more than 38.3 degrees Celsius, give 4-6 ml (Paraped or Calpol) every 4-6 hours. RECORD IN THE DIARY EVERY ADMINISTRATION! "
             };
             var ibuprofen = new Pill()
             {
                 Name = "Ibuprofen",
                 Quantity = 2,
                 Days = 5,
                 UnitOfMeasure = UnitOfMeasure.Mills,
                 Comment =
                     "When he has fever more than 38.3 degrees Celsius, give 2.5 ml (Fenopine or Nurofen) every 6-8 hours. RECORD IN THE DIARY EVERY ADMINISTRATION!. If the fever is more than 39.2 degrees Celsius, give up to 5 ml, undress him and put wet socks and give him plenty of fluids!"
             };
             context.Pills.AddOrUpdate(p=>p.Name,
                 smecta, enterol, paracetamol, ibuprofen);

             var breakfastOddDays = new Meal()
             {
                 Name = "Breakfast - odd days",
                 Recipe =
                     "1 boiled egg + veg / rice, milk made out of 8 teaspoons of milk + 1 teaspoon of cream/butter/margarine",
                 Comment = "Aim to give high proten high caloric food at the beginning of the day"
             };

             var breakfastEvenDays = new Meal()
             {
                 Name = "Breakfast - even days",
                 Recipe =
                     "Oat porridge: 8 teaspoons of milk, 2 tablespoons of porridge, 100 ml water, 1 teaspoon butter/margarine, 2 dried plums, 4 half walnuts, one teaspoon of coconut oil"

             };

             var snack = new Meal()
             {
                 Name = "Snack",
                 Recipe = "Biscuits, 1 banana, walnuts, dried plums"
             };

             var lunch = new Meal()
             {
                 Name = "Lunch",
                 Recipe = "Potato puree or pasta with chicken/fish/meat and cream/butter. Milk after lunch."
             };

             var dinner = new Meal()
             {
                 Name = "Dinner",
                 Recipe =
                     "Rice porridge: 8 teaspoons of milk, 2 tablespoons of boiled rice, apple puree or cooked apple, nuts and one teaspoon of coconut oil."
             };
             context.Meals.AddOrUpdate(p=>p.Name,
                 breakfastEvenDays, breakfastOddDays, snack, lunch, dinner);
        }
    }
}


