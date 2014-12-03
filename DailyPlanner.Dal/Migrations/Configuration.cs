using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;

using DailyPlanner.Dal.DbContexts;
using DailyPlanner.DomainClasses;

namespace DailyPlanner.Dal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DailyPlanner.Dal.DbContexts.DailyPlannerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
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
        }
    }
}


