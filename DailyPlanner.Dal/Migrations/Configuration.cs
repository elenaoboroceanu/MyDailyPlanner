using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;

using DailyPlanner.Dal.DbContexts;
using DailyPlanner.DomainClasses;

namespace DailyPlanner.Dal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DailyPlannerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DailyPlanner.Models.DailyPlannerDbContext";
        }

        protected override void Seed(DailyPlannerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            // PopulateDatabase(context);
        }

        private static void PopulateDatabase(DailyPlannerDbContext context)
        {
            var eating = new ActivityType {Name = "Eating"};
            var nightSleep = new ActivityType {Name = "Night time sleep"};
            var bathActivityType = new ActivityType {Name = "Bathing"};
            var nap = new ActivityType {Name = "Taking a nap"};
            var homeTeacherActivity = new ActivityType {Name = "Home Teacher-St. Michael's House"};
            var nacdActivity = new ActivityType {Name = "NACD"};

            context.ActivityTypes.AddOrUpdate(
                p => p.Name,
                eating,
                nightSleep,
                bathActivityType,
                nap,
                new ActivityType {Name = "Other activities of Daily Living-eg. nappy changing"},
                new ActivityType {Name = "Structured Activities"},
                new ActivityType {Name = "Leisure Time"},
                new ActivityType {Name = "Travel"},
                new ActivityType {Name = "Unstructured Down Time"},
                nacdActivity,
                new ActivityType {Name = "Occupational-St. Michael's House"},
                new ActivityType {Name = "Phisio-St. Michael's House"},
                homeTeacherActivity,
                new ActivityType {Name = "Speech and Language-St. Michael's House"},
                new ActivityType {Name = "Pre-school"}
                );

            var homeTeacherToy = new ToyType
            {
                Name = "From Home Teacher",
                Description = "Toys brought from home teacher"
            };
            var personalToy = new ToyType {Name = "Personal Toy"};
            context.ToyTypes.AddOrUpdate(
                p => p.Name,
                homeTeacherToy,
                new ToyType {Name = "From Occupational Therapist"},
                new ToyType {Name = "From Speach and Language Therapist"},
                new ToyType {Name = "From Phisio Therapist"},
                personalToy
                );

            var bedroom = new FlashcardType {Name = "Bedroom", Description = "Toys brought from home teacher"};
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
                Name = "HT:Color match: rings on sticks",
                Description = "He has to match colors on sticks",
                ToyType = homeTeacherToy,
                ToyTypeId = homeTeacherToy.Id
            };
            var carsOnWhireToy = new Toy
            {
                Name = "HT:Threading: cars on a wire",
                Description = "Put cars on whire",
                ToyType = homeTeacherToy,
                ToyTypeId = homeTeacherToy.Id
            };

            context.Toys.AddOrUpdate(
                p => p.Name,
                drawingBook,
                playDough,
                ringsOnSticks,
                riceInCups,
                new Toy
                {
                    Name = "HT:Bowling",
                    Description = "Bowling set from HT",
                    ToyType = homeTeacherToy,
                    ToyTypeId = homeTeacherToy.Id
                },
                carsOnWhireToy,
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
                ActivityType = homeTeacherActivity,
                ActivityTypeId = homeTeacherActivity.Id,
                Flashcards = new Collection<Flashcard>(),
                Toys = new Collection<Toy>() {carsOnWhireToy}
            };

            var flashcardsBathActivity = new Activity()
            {
                Name = "10 flashcards related to bathroom",
                Description = "Toilet, shower, toothbrush, mirror, sink, tap, towel, bath, toothpaste, soap",
                ActivityType = nacdActivity,
                ActivityTypeId = nacdActivity.Id,
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
                flashcardsBathActivity);
        }
    }
}