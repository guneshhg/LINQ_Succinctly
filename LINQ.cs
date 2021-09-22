/////////////////////////////////////////////////////////////

  		     int[] fibonnacci = { 0, 1, 1, 2, 3, 5 };

            int numberOfElements = fibonnacci.Count();

            IEnumerable<int> distinctNumbers = fibonnacci.Distinct();
            Console.WriteLine("Elements in output sequence:");
            foreach (var number in distinctNumbers)
            {
                Console.WriteLine(number);
            }

/////////////////////////////////////////////////////////////

			int[] fibonacci = { 0, 1, 1, 2, 3, 5 };
            IEnumerable<int> numbersGreaterThanTwoQuery = fibonacci.Where(x => x > 2);

            fibonacci[0] = 99;

            foreach (var number in numbersGreaterThanTwoQuery)
            {
                Console.WriteLine(number);
            }
/////////////////////////////////////////////////////////////


 			Ingredient[] ingredients =
            {
              new Ingredient{Name = "Sugar", Calories=500},
              new Ingredient{Name = "Egg", Calories=100},
              new Ingredient{Name = "Milk", Calories=150},
              new Ingredient{Name = "Flour", Calories=50},
              new Ingredient{Name = "Butter", Calories=200}
            };

            IEnumerable<string> highCalorieIngreientNamesQuery =
                        ingredients.Where(x => x.Calories >= 150)
                        .OrderBy(x => x.Name)
                        .Select(x => x.Name);

            foreach (var ingredientName in highCalorieIngreientNamesQuery)
            {
                Console.WriteLine(ingredientName);
            }


/////////////////////////////////////////////////////////////

  Ingredient[] ingredients =
                 {
                 new Ingredient{Name = "Sugar", Calories=500},
                 new Ingredient{Name = "Egg", Calories=100},
                 new Ingredient{Name = "Milk", Calories=150},
                 new Ingredient{Name = "Flour", Calories=50},
                 new Ingredient{Name = "Butter", Calories=200}
                };

            IEnumerable<string> highCalorieIngredientNamesQuery =
                                from i in ingredients
                                where i.Calories > 150
                                orderby i.Name
                                select i.Name;

            foreach (var ingredientName in highCalorieIngredientNamesQuery)
            {
                Console.WriteLine(ingredientName);
            }

/////////////////////////////////////////////////////////////

  Ingredient[] ingredients =
             {
             new Ingredient{Name = "Sugar", Calories=500},
             new Ingredient{Name = "Egg", Calories=100},
             new Ingredient{Name = "Milk", Calories=150},
             new Ingredient{Name = "Flour", Calories=50},
             new Ingredient{Name = "Butter", Calories=200}
            };


            IEnumerable<Ingredient> highCalDiaryQuery =
                                   from i in ingredients
                                   let isDairy = i.Name == "Milk" || i.Name == "Butter"
                                   where i.Calories >= 150 && isDairy
                                   select i;


/////////////////////////////////////////////////////////////

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Review
    {
        public int RecipeId { get; set; }
        public string ReviewText { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //INNER JOIN
            Recipe[] recipes =
            {
             new Recipe {Id = 1, Name = "Mashed Potato"},
             new Recipe {Id = 2, Name = "Crispy Duck"},
             new Recipe {Id = 3, Name = "Sachertorte"}
            };
           Review[] reviews =
           {
             new Review {RecipeId = 1, ReviewText = "Tasty!"},
             new Review {RecipeId = 1, ReviewText = "Not nice :("},
             new Review {RecipeId = 1, ReviewText = "Pretty good"},
             new Review {RecipeId = 2, ReviewText = "Too hard"},
             new Review {RecipeId = 2, ReviewText = "Loved it"}
            };


            var query = from recipe in recipes
                        join review in reviews on recipe.Id equals review.RecipeId
                        select new
                        {
                            RecipeName = recipe.Name,
                            RecipeReview = review.ReviewText
                        };

            foreach (var item in query)
            {
                Console.WriteLine("{0} - {1}",item.RecipeName,item.RecipeReview);
            }


/////////////////////////////////////////////////////////////
GROUP JOIN

 public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Review
    {
        public int RecipeId { get; set; }
        public string ReviewText { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //INNER JOIN
            Recipe[] recipes =
            {
             new Recipe {Id = 1, Name = "Mashed Potato"},
             new Recipe {Id = 2, Name = "Crispy Duck"},
             new Recipe {Id = 3, Name = "Sachertorte"}
            };
           Review[] reviews =
           {
             new Review {RecipeId = 1, ReviewText = "Tasty!"},
             new Review {RecipeId = 1, ReviewText = "Not nice :("},
             new Review {RecipeId = 1, ReviewText = "Pretty good"},
             new Review {RecipeId = 2, ReviewText = "Too hard"},
             new Review {RecipeId = 2, ReviewText = "Loved it"}
            };


            var query = from recipe in recipes
                        join review in reviews on recipe.Id equals review.RecipeId
                        into reviewGroup
                        select new
                        {
                            RecipeName = recipe.Name,
                            Reviews = reviewGroup
                        };
            foreach (var item in query)
            {
                Console.WriteLine("Reviews for {0}",item.RecipeName);
                foreach (var review in item.Reviews)
                {
                    Console.WriteLine("- {0}",review.ReviewText);
                }
            }

/////////////////////////////////////////////////////////////
LEFT JOIN

 public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Review
    {
        public int RecipeId { get; set; }
        public string ReviewText { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
       
            Recipe[] recipes =
            {
             new Recipe {Id = 1, Name = "Mashed Potato"},
             new Recipe {Id = 2, Name = "Crispy Duck"},
             new Recipe {Id = 3, Name = "Sachertorte"}
            };
           Review[] reviews =
           {
             new Review {RecipeId = 1, ReviewText = "Tasty!"},
             new Review {RecipeId = 1, ReviewText = "Not nice :("},
             new Review {RecipeId = 1, ReviewText = "Pretty good"},
             new Review {RecipeId = 2, ReviewText = "Too hard"},
             new Review {RecipeId = 2, ReviewText = "Loved it"}
            };

            var query = from recipe in recipes
                        join review in reviews on recipe.Id equals review.RecipeId
                        into reviewGroup
                        from rg in reviewGroup.DefaultIfEmpty()
                        select new
                        {
                            RecipeName = recipe.Name,
                            RecipeReview = (rg == null ? "n/a" : rg.ReviewText)
                        };

            foreach (var item in query)
            {
                Console.WriteLine("{0} - {1}",item.RecipeName,item.RecipeReview);
            }

/////////////////////////////////////////////////////////////
LEFT JOIN

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Review
    {
        public int RecipeId { get; set; }
        public string ReviewText { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        
            Recipe[] recipes =
            {
             new Recipe {Id = 1, Name = "Mashed Potato"},
             new Recipe {Id = 2, Name = "Crispy Duck"},
             new Recipe {Id = 3, Name = "Sachertorte"}
            };
           Review[] reviews =
           {
             new Review {RecipeId = 1, ReviewText = "Tasty!"},
             new Review {RecipeId = 1, ReviewText = "Not nice :("},
             new Review {RecipeId = 1, ReviewText = "Pretty good"},
             new Review {RecipeId = 2, ReviewText = "Too hard"},
             new Review {RecipeId = 2, ReviewText = "Loved it"}
            };


            var query = from recipe in recipes
                        join review in reviews on recipe.Id equals review.RecipeId
                        into reviewGroup
                        from rg in reviewGroup.DefaultIfEmpty(new Review { ReviewText = "n\a" })
                        select new
                        {
                            RecipeName = recipe.Name,
                            RecipeReview = rg.ReviewText
                        };

            foreach (var item in query)
            {
                Console.WriteLine("{0} - {1}",item.RecipeName,item.RecipeReview);
            }


/////////////////////////////////////////////////////////////

  public class Ingredient
    {
        public string Name { get; set; }
        public int Calories { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Ingredient[] ingredients =
            {
                 new Ingredient{Name = "Sugar", Calories=500},
                 new Ingredient{Name = "Lard", Calories=500},
                 new Ingredient{Name = "Butter", Calories=500},
                 new Ingredient{Name = "Egg", Calories=100},
                 new Ingredient{Name = "Milk", Calories=100},
                 new Ingredient{Name = "Flour", Calories=50},
                 new Ingredient{Name = "Oats", Calories=50}

            };

            var query = from i in ingredients
                        group i by i.Calories;

            foreach (var group in query)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine("- {0}",item.Name);
                }
            }

/////////////////////////////////////////////////////////////

 Ingredient[] ingredients =
            {
                 new Ingredient{Name = "Sugar", Calories=500},
                 new Ingredient{Name = "Lard", Calories=500},
                 new Ingredient{Name = "Butter", Calories=500},
                 new Ingredient{Name = "Egg", Calories=100},
                 new Ingredient{Name = "Milk", Calories=100},
                 new Ingredient{Name = "Flour", Calories=50},
                 new Ingredient{Name = "Oats", Calories=50}
            };

            var sortedByNameQuery =
                from i in ingredients
                orderby i.Name
                select i;

            foreach (var item in sortedByNameQuery)
            {
                Console.WriteLine(item.Name);
            }

/////////////////////////////////////////////////////////////

 			 Ingredient[] ingredients =
            {
                 new Ingredient{Name = "Sugar", Calories=500},
                 new Ingredient{Name = "Lard", Calories=500},
                 new Ingredient{Name = "Butter", Calories=500},
                 new Ingredient{Name = "Egg", Calories=100},
                 new Ingredient{Name = "Milk", Calories=100},
                 new Ingredient{Name = "Flour", Calories=50},
                 new Ingredient{Name = "Oats", Calories=50}
            };
            var query = ingredients.Where(x => x.Calories >= 200);
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }


/////////////////////////////////////////////////////////////

 Ingredient[] ingredients =
            {
                 new Ingredient{Name = "Sugar", Calories=500},
                 new Ingredient{Name = "Lard", Calories=500},
                 new Ingredient{Name = "Butter", Calories=500},
                 new Ingredient{Name = "Egg", Calories=100},
                 new Ingredient{Name = "Milk", Calories=100},
                 new Ingredient{Name = "Flour", Calories=50},
                 new Ingredient{Name = "Oats", Calories=50}
            };

            var query = ingredients.Select(x=>x.Name);
            var queryNameLength = ingredients.Select(x => x.Name.Length);

            foreach (var item in queryNameLength)
            {
                Console.WriteLine($"{item}");
            }

/////////////////////////////////////////////////////////////

			 Ingredient[] ingredients =
            {
                 new Ingredient{Name = "Sugar", Calories=500},
                 new Ingredient{Name = "Lard", Calories=500},
                 new Ingredient{Name = "Butter", Calories=500},
                 new Ingredient{Name = "Egg", Calories=100},
                 new Ingredient{Name = "Milk", Calories=100},
                 new Ingredient{Name = "Flour", Calories=50},
                 new Ingredient{Name = "Oats", Calories=50}
            };

            IEnumerable<Ingredient> query = ingredients.Where(x => x.Calories > 100)
                                                       .Take(2);

            foreach (var ingredient in query)
            {
                Console.WriteLine(ingredient.Name);
            }


/////////////////////////////////////////////////////////////

			Ingredient[] ingredients =
            {
                 new Ingredient{Name = "Sugar", Calories=500},
                 new Ingredient{Name = "Lard", Calories=500},
                 new Ingredient{Name = "Butter", Calories=500},
                 new Ingredient{Name = "Egg", Calories=100},
                 new Ingredient{Name = "Milk", Calories=100},
                 new Ingredient{Name = "Flour", Calories=50},
                 new Ingredient{Name = "Oats", Calories=50}
            };

            IEnumerable<Ingredient> query = ingredients.TakeWhile(x => x.Calories >= 100);
            foreach (var ingredient in query)
            {
                Console.WriteLine(ingredient.Name);
            }


/////////////////////////////////////////////////////////////

 Ingredient[] ingredients =
            {
                 new Ingredient{Name = "Sugar", Calories=500},
                 new Ingredient{Name = "Lard", Calories=500},
                 new Ingredient{Name = "Butter", Calories=500},
                 new Ingredient{Name = "Egg", Calories=100},
                 new Ingredient{Name = "Milk", Calories=100},
                 new Ingredient{Name = "Flour", Calories=50},
                 new Ingredient{Name = "Oats", Calories=50}
            };

            string[] ingredients2 =
            {
                "Sugar",
                "Egg",
                "Milk",
                "Flour",
                "Butter"
            };
            var query = ingredients2.OrderByDescending(x => x);
            var query2 = ingredients.OrderBy(x => x.Calories);
            foreach (var item in query2)
            {
                Console.WriteLine($"{item.Name} {item.Calories}");
            }

/////////////////////////////////////////////////////////////

 		     Ingredient[] ingredients =
            {
                 new Ingredient{Name = "Sugar", Calories=500},
                 new Ingredient{Name = "Lard", Calories=500},
                 new Ingredient{Name = "Butter", Calories=500},
                 new Ingredient{Name = "Egg", Calories=100},
                 new Ingredient{Name = "Milk", Calories=100},
                 new Ingredient{Name = "Flour", Calories=50},
                 new Ingredient{Name = "Oats", Calories=50}
            };

            var query = ingredients.OrderBy(x => x.Calories)
                                    .ThenByDescending(x => x.Name);

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " " + item.Calories);
            }

/////////////////////////////////////////////////////////////

			char[] letters = { 'A', 'B', 'C' };
            var query = letters.Reverse();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }


/////////////////////////////////////////////////////////////

			Ingredient[] ingredients =
             {
             new Ingredient{Name = "Sugar", Calories=500},
             new Ingredient{Name = "Lard", Calories=500},
             new Ingredient{Name = "Butter", Calories=500},
             new Ingredient{Name = "Egg", Calories=100},
             new Ingredient{Name = "Milk", Calories=100},
             new Ingredient{Name = "Flour", Calories=50},
             new Ingredient{Name = "Oats", Calories=50}

            };

            var query = ingredients.GroupBy(x => x.Calories);

            foreach (var group in query)
            {
                Console.WriteLine("Ingredients with {0} calories",group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("{0}",item.Name);
                }
            }

/////////////////////////////////////////////////////////////

			string[] applePie = { "Apple", "Sugar", "Pastry", "Cinnamon" };
            string[] cherryPie = { "Cherry", "Sugar", "Pastry", "Kirsch" };


            IEnumerable<string> query = applePie.Concat(cherryPie);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

/////////////////////////////////////////////////////////////

			string[] applePie = { "Apple", "Sugar", "Pastry", "Cinnamon" };
            string[] cherryPie = { "Cherry", "Sugar", "Pastry", "Kirsch" };

            IEnumerable<string> query = applePie.Union(cherryPie);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            	

/////////////////////////////////////////////////////////////

			string[] applePie = { "Apple", "Sugar", "Pastry", "Cinnamon" };
            string[] cherryPie = { "Cherry", "Sugar", "Pastry", "Kirsch" };

            IEnumerable<string> query = applePie.Concat(cherryPie).Distinct();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

/////////////////////////////////////////////////////////////

			string[] applePie = { "Apple", "Sugar", "Pastry", "Cinnamon" };
            string[] cherryPie = { "Cherry", "Sugar", "Pastry", "Kirsch" };

            IEnumerable<string> query = applePie.Intersect(cherryPie);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

/////////////////////////////////////////////////////////////

 			string[] applePie = { "Apple", "Sugar", "Pastry", "Cinnamon" };
            string[] cherryPie = { "Cherry", "Sugar", "Pastry", "Kirsch" };

            IEnumerable<string> query = applePie.Except(cherryPie);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }


/////////////////////////////////////////////////////////////

			IEnumerable input = new object[]
            {
                44,'a',"asdf",new DateTime()
            };

            var query = input.OfType<string>();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

/////////////////////////////////////////////////////////////

			IEnumerable<Ingredient> input = new Ingredient[]
            {
                new DryIngredient{ Name = "Flour"},
                 new WetIngredient{Name = "Milk"},
                new WetIngredient{Name = "Water"}

            };

            IEnumerable<WetIngredient> query = input.OfType<WetIngredient>();
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }


/////////////////////////////////////////////////////////////

            IEnumerable<string> input = new List<string> { "Apple", "Sugar", "Flour" };
            string[] array = input.ToArray();


/////////////////////////////////////////////////////////////

 			  IEnumerable<Recipe> recipes = new[]
            {
                new Recipe {Id = 1, Name = "Apple Pie", Rating = 5},
                new Recipe {Id = 2, Name = "Cherry Pie", Rating = 2},
                new Recipe {Id = 3, Name = "Beef Pie", Rating = 3}
            };

            var dict = recipes.ToDictionary(x => x.Name);
            
            foreach (var item in dict)
            {
                Console.WriteLine($"Key={0},Recipe={1}",item.Key,item.Value.Name);
            }

/////////////////////////////////////////////////////////////


   			  Ingredient[] ingredients =
            {
             new Ingredient {Name = "Sugar", Calories = 500},
             new Ingredient {Name = "Egg", Calories = 100},
             new Ingredient {Name = "Milk", Calories = 150},
             new Ingredient {Name = "Flour", Calories = 50},
             new Ingredient {Name = "Butter", Calories = 500}
            };

            Ingredient element = ingredients.First(); 
			Ingredient element = ingredients.First(x=>x.Calories==150); //bulamazsa exp atar
			Ingredient element = ingredients.FirstOrDefault(x=>x.Calories==9999);
			Ingredient element = ingredients.Last(x => x.Calories == 50);


            
			Console.WriteLine(element.Name);

/////////////////////////////////////////////////////////////

			Ingredient[] ingredients =
            {
                new Ingredient{Name="Sugar",Calories=500},
                new Ingredient{Name="Butter",Calories=150},
                new Ingredient{Name="Milk",Calories=500}
            };
       
                Ingredient element = ingredients.Single(x => x.Calories == 500);
				Ingredient element = ingredients.SingleOrDefault(x => x.Calories == 9999);

                Console.WriteLine(element.Name);

/////////////////////////////////////////////////////////////


			Ingredient[] ingredients =
            {
             new Ingredient {Name = "Sugar", Calories = 500},
             new Ingredient {Name = "Egg", Calories = 100},
             new Ingredient {Name = "Milk", Calories = 100}
            };

            Ingredient element = ingredients.SingleOrDefault(x => x.Calories == 100);

exception atar


/////////////////////////////////////////////////////////////

 			Ingredient[] ingredients =
            {
             new Ingredient {Name = "Sugar", Calories = 500},
             new Ingredient {Name = "Egg", Calories = 100},
             new Ingredient {Name = "Milk", Calories = 50}
            };

            Ingredient element = ingredients.ElementAt(2);
            Ingredient element2 = ingredients.ElementAtOrDefault(4);
            Console.WriteLine(element==null);
            
            Console.WriteLine(element.Name);

/////////////////////////////////////////////////////////////

			Ingredient[] ingredients =
            {
                new Ingredient {Name = "Sugar", Calories = 500},
                 new Ingredient {Name = "Egg", Calories = 100},
                 new Ingredient {Name = "Milk", Calories = 50}
            };
            IEnumerable<Ingredient> query = ingredients.DefaultIfEmpty();

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

/////////////////////////////////////////////////////////////


 			IEnumerable<int> fiveToTen = Enumerable.Range(5, 6);

            foreach (int num in fiveToTen)
            {
                Console.WriteLine(num);
            }

/////////////////////////////////////////////////////////////

			IEnumerable<int> nums = Enumerable.Repeat(42, 5);

            foreach (int num in nums)
            {
                Console.WriteLine(num);
            }

/////////////////////////////////////////////////////////////

 			int[] nums = { 1, 2, 3 };
            bool isTwoThere = nums.Contains(2);
            bool isFiveThere = nums.Contains(5);

            Console.WriteLine(isTwoThere);
            Console.WriteLine(isFiveThere);

/////////////////////////////////////////////////////////////

			int[] nums = { 1, 2, 3 };
            IEnumerable<int> noNums = Enumerable.Empty<int>();

            Console.WriteLine(nums.Any());
            Console.WriteLine(noNums.Any());

/////////////////////////////////////////////////////////////

			int[] nums = { 1, 2, 3 };
            bool areAnyEvenNumber = nums.Any(x => x % 2 == 0);
            Console.WriteLine(areAnyEvenNumber);

/////////////////////////////////////////////////////////////

			Ingredient[] ingredients =
            {
                 new Ingredient {Name = "Sugar", Calories = 500},
                 new Ingredient {Name = "Egg", Calories = 100},
                 new Ingredient {Name = "Milk", Calories = 150},
                 new Ingredient {Name = "Flour", Calories = 50},
                 new Ingredient {Name = "Butter", Calories = 400}
            };

            bool isLowFatRecipe = ingredients.All(x => x.Calories < 200);
            Console.WriteLine(isLowFatRecipe);
			
/////////////////////////////////////////////////////////////

			IEnumerable<int> sequance1 = new[] { 1, 2, 3 };
            IEnumerable<int> sequence2 = new[] { 1, 2, 3 };

            bool isSeqEqual = sequance1.SequenceEqual(sequence2);
            Console.WriteLine(isSeqEqual);

/////////////////////////////////////////////////////////////

 			 int[] nums = { 1, 2, 3 };
            int numberOfElements = nums.Count();
            Console.WriteLine(numberOfElements);

/////////////////////////////////////////////////////////////

 			int[] nums = { 1, 2, 3 };
            int numberOfOddElements = nums.Count(x =>x % 2 == 1);
            Console.WriteLine(numberOfOddElements);

/////////////////////////////////////////////////////////////


            int[] nums = { 1, 2, 3 };
            int total = nums.Sum();
            Console.WriteLine(total);

/////////////////////////////////////////////////////////////

 			Ingredient[] ingredients =
            {
             new Ingredient {Name = "Sugar", Calories = 500},
             new Ingredient {Name = "Egg", Calories = 100},
             new Ingredient {Name = "Milk", Calories = 150},
             new Ingredient {Name = "Flour", Calories = 50},
             new Ingredient {Name = "Butter", Calories = 400}
            };

            int totalCalories = ingredients.Sum(x => x.Calories);

            Console.WriteLine(totalCalories);

/////////////////////////////////////////////////////////////

			 int[] nums = { 1, 2, 3 };
            var avg = nums.Average();
            Console.WriteLine(avg);

/////////////////////////////////////////////////////////////

			Ingredient[] ingredients =
            {
             new Ingredient {Name = "Sugar", Calories = 500},
             new Ingredient {Name = "Egg", Calories = 100},
             new Ingredient {Name = "Milk", Calories = 150},
             new Ingredient {Name = "Flour", Calories = 50},
             new Ingredient {Name = "Butter", Calories = 400}
            };

            var smallestCalories = ingredients.Min(x => x.Calories);
            Console.WriteLine(smallestCalories);

/////////////////////////////////////////////////////////////

int[] nums = { 1, 3, 2 };
var largest = nums.Max();
Console.WriteLine(largest);

/////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////


