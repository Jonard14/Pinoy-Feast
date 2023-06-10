-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 07, 2023 at 02:37 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `foodinfo`
--

-- --------------------------------------------------------

--
-- Table structure for table `foodcategory`
--

CREATE TABLE `foodcategory` (
  `name` varchar(100) NOT NULL,
  `status` tinyint(4) NOT NULL,
  `region` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

INSERT INTO `foodcategory` (`name`, `status`, `region`) VALUES
('Adobo', 0, 'Pinoy Classics'),
('Bagnet', 0, 'Region I'),
('Bopis', 0, 'Region IV-A'),
('Buko Pie', 0, 'Region IV-A'),
('Bulalo', 0, 'Region IV-A'),
('Dinuguan', 0, 'Pinoy Classics'),
('Inasal', 0, 'Region VI'),
('Kare-Kare', 0, 'Region III'),
('Laing', 0, 'Region V'),
('Lechon', 0, 'Region VII'),
('Pancit Palabok', 1, 'NCR'),
('Pinakbet', 0, 'Region I'),
('Sinigang', 1, 'Pinoy Classics'),
('Sisig', 0, 'Region III'),
('Tapa', 1, 'Pinoy Classics'),
('Pancit Batil Patung', 0, 'Region II'),
('Ginataang Alimasag',0,'Region II');



CREATE TABLE `fooddesc` (
  `name` varchar(100) NOT NULL,
  `imgfile` varchar(100) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

INSERT INTO `fooddesc` (`name`, `imgfile`, `description`) VALUES
('Adobo', 'ADOBO', 'Considered as the Philippine\'s national dish because of popularity.It is made by marinated chicken / pork mixed in vinegar, soy sauce, garlic and spices thus making it savory and tangy with a hint of sweetnes.'),
('Bagnet', 'BAGNET', 'It\'s a dish originated from the Ilocos region in the Philippines. It is a deep-fried pork belly dish known for its crispy and flavorful texture. Bagnet is a versatile dish and can be enjoyed in different ways. It can be served as a main dish with rice, paired with vegetables or salad, or used as an ingredient in other Filipino dishes like pinakbet or kare-kare.'),
('Bopis', 'BOPIS', 'It\'s a dish made from minced pork lungs and heart, cooked with various spices and vegetables. It is known for its bold and spicy flavors.Bopis is commonly enjoyed as a pulutan (appetizer or beer match) or as a main dish with steamed rice. Its bold flavors make it a popular choice in gatherings and celebrations, particularly during festivities or drinking sessions. Bopis showcases the creative use of offal in Filipino cuisine, offering a unique and flavorful experience.'),
('Buko Pie', 'BUKO_PIE', 'It\'s a pastry type food made with buko. It\'s also a popular dessert or snack in the Philippines, especially in the areas where coconuts are abundant. It has a flaky crust filled with a mixture of buko, sugar, and condensed milk. Buko pie can be enjoyed on its own or with a scoop of vanilla ice cream for an extra indulgent treat. It is a beloved dessert in Filipino cuisine and is a must-try for coconut lovers and pastry enthusiasts.'),
('Bulalo', 'BULALO', 'It\'s a beef soup dish that is often enjoyed during cool weather. It is made by cooking beef shanks and bone marrow along with various vegetables and seasonings.'),
('Dinuguan', 'DINUGUAN', 'It\'s a pork stew primarily made from pork parts I.e.lungs, kidneys,intestines,ears,heart, snout and its blood. Famously known as \'chocolate meat\' / \'blood stew\'. It\'s enjoyed along with steamed rice and it\'s usually can be a filling for \'puto\'. Despite of it being a unique dish, it\'s still beloved and widely enjoyed by Filipino people.'),
('Inasal', 'INASAL', 'Inasal is a grilled chicken dish that hails from the province of Bacolod in the Philippines. It is known for its distinct flavor, which comes from a combination of tanginess and smokiness. Inasal is often served with a side of sinamak, a spicy vinegar dip, which adds an extra kick of flavor. It is commonly enjoyed with steamed rice and a side of pickled papaya or atchara.'),
('Kare-Kare', 'KARE_KARE', 'It\'s a stew dish made with oxtail, tripe, and beef, along with various vegetables. It\'s famous for having a flavorful peanut sauce that is made of a combination of ingredients I.e. ground peanuts, shrimp paste, garlic, onions, and annatto oil. It is a beloved dish that showcases the rich culinary heritage of the Philippines.'),
('Laing', 'LAING', 'It\'s a famous dish known as being flavorful and spicy, it\'s primarily made with meat / seafood, taro leaves, coconut milk, and various aromatics. The combination of coconut milk and shrimp paste gives laing its distinct flavor, thus making it creamy, savory and spicy. It\'s commonly served as a main dish or a side dish and beloved by Bicol people where the dish originated.'),
('Lechon', 'LECHON', 'It\'s a roasted whole pig that\'s slowly-roasted on a large bamboo spit over an open fire and it\'s usually stuffed  with a mixture of herbs, spices, and aromatics. It\'s usually served on festive occassions such as weddings, birthdays, and holidays.'),
('Pancit Palabok', 'PANCIT_PALABOK', 'A noodle type dish that is served during special occasions and celebrations and it\'s also known as \'Pancit Luglug or Pancit Malabon\'. It\'s made with rice noodles, palabok sauce and garnished with different toppings I.e. smoked fish, eggs, chicharon and shrimps.'),
('Pinakbet', 'PINAKBET', 'It\'s a famous vegetable dish made from a variety of vegetables. It hails from the Ilocos region of the Philippines and is known for its use of bagoong (shrimp paste) as a key ingredient. It\'s beloved by its vibrant colors, flavorful combinations of vegetables, and the umami richness brought by the shrimp paste.'),
('Sinigang', 'SINIGANG', 'It\'s a soup known for its sour and savory flavor primarily made with tamarind-based soup with various meat / seafood along with vegetables. It\'s often considered as comfort food and enjoyed during cool weather.'),
('Sisig', 'SISIG', 'Made from parts of a pig\'s head I.e. cheeks, ears, and snout. Often cooked with onions and garlic to enhance its aroma and topped with a raw egg. It\'s also commonly served as a main course / appetizer (pulutan).'),
('Tapa', 'TAPA', 'Tapa is a popular dish made from marinated thinly sliced variety of meats i.e. beef, pork, and horse. It\'s often served in any \'Karinderya\' as tapsilog (tapa alongside with sunny side up egg) with sinigang soup. It\'s commonly enjoyed as a breakfast or brunch. '),
('Pancit Batil Patung','PANCIT_BATIL','Pancit Batil Patung is a popular noodle dish in Tuguegarao City, Cagayan. It is composed of two parts: the noodles with toppings, and the sauce which looks like an egg drop soup. Poached egg along with sauteed meats and vegetables are topped over the fresh miki noodles, while a piece of egg is cracked and stirred-in simmering beef'),
('Ginataang Alimasag','GINATAANG_ALIMASAG','Ginataang Alimasag are Crabs cooked in Coconut Milk. This recipe features the use of spinach and Thai chili as a replacement for Malunggay. Squash and string beans (kalabasa and sitaw) can also be placed instead of Spinach (or Malunggay).');

CREATE TABLE `foodrecipe` (
  `name` varchar(100) NOT NULL,
  `ingredients` text NOT NULL,
  `steps` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

INSERT INTO `foodrecipe` (`name`, `ingredients`, `steps`) VALUES
('Adobo', 'Ingredients\n2 tbsp canola oil\n
6 cloves garlic crushed\n
1 pc onion, sliced\n
1 kilogram chicken cut ups\n
2 tbsp vinegar\n
1/4 cup soy sauce\n
1 cup water\n
2 pcs bay leaves\n
1 tsp whole black peppercorns, slightly crushed\n
2 pc Knorr chicken cubes\n
1 tsp brown sugar packed\n
Option: 1 cup kale or spinach\n\n', 'Instruction:\n
Heat oil in pan and sauté garlic and onions. Then add chicken to the pan and sear on all sides, until you have a little browning in the chicken skin.\n
Pour in vinegar, soy sauce and water. Add bay leaves, pepper and Knorr Chicken Cubes. Bring to a boil over high heat then reduce heat to simmer, but do not cover the pan. Continue to simmer for 10 mins.\n
Remove chicken pieces from sauce and fry in another pan until nicely browned.\n
Put back fried chicken pieces into sauce. Add sugar and let simmer again for another 10 minutes or until sauce has thickened. Serve warm.'),
('Bopis', 'Ingredients:\n
3 lbs pork lungs\n
1 Knorr Pork Cube\n
5 dried bay leaves\n
2 carrots diced\n
3 thumbs ginger minced\n
1 tablespoon annatto powder\n
3 Thai chili pepper chopped\n
1 onion diced\n
5 cloves garlic minced\n
5 tablespoons vinegar\n
2 ½ cups water\n
¼ teaspoon ground black pepper\n
4 tablespoons cooking oil\n
Fish sauce to taste\n', 'In a large pot, boil 8 cups of water and then add the rest of the boiling ingredients.\n Put the pig’s lungs into the pot and continue boiling for 1 hours.\n Remove the lungs, let it cool down, and then dice into small pieces. Set aside.\n
Heat oil on a clean pot. Sauté garlic, onion, and ginger.\n
Add the diced lungs once the onion softens. Cook for 3 minutes while stirring.\n
Add vinegar. Cook for 2 minutes.\n
Pour 2 ½ cups of water into the pot. Let it boil.\n
Add Knorr Pork cube and bay leaves. Stir.\n Cover the pot and adjust the heat between low to medium setting. Continue cooking until the liquid reduces to half.\n
Add the carrot, chili pepper, and annatto powder. Cook for 3 minutes.\n
Season with ground black pepper and fish sauce.\n
Transfer to a serving plate. Share and enjoy!\n'),
('Buko Pie', 'Ingredients:\n 2 cups all-purpose flour\n
1/3 cup butter\n
1 teaspoon salt\n
1/3 cup vegetable shortening\n
6 to 8 tablespoons cold water\n
2 cups young coconut meat\n
3/4 cup granulated white sugar\n
1/2 cup cornstarch diluted in 1/2 cup young coconut water\n
1/2 cup evaporated milk\n', 'Instructions:\nCreate the crust. Combine flour and salt then mix using a balloon whisk. Add butter and shortening then mix using a pastry mixer. Gradually add cold water a tablespoon at a time while mixing the ingredients. When everything is completely mixed, gather the mixture and divide into two equal parts. In a flat surface flatten each of the dough and roll using a rolling pin until wide enough to fit an eight or nine inch cake pan. Note: Sprinkle flour over the flat surface to prevent the dough from sticking or use a silicon mat. Arrange the first dough over the cake pan. This will be the base. Set the second flattened dough aside. This will be needed after arranging the filling in the cake pan.\n
Make the filling by heating a saucepan and pour-in the milk. Let boil.\n
Add the granulated white sugar and stir.\n
Put-in the young coconut meat and cook for 3 minutes.\n
Pour-in the cornstarch diluted in young coconut water and stir thoroughly while cooking. Cook until the texture thickens.\n
Turn-off the heat and allow the mixture to cool down.\n
Preheat oven to 375 degrees Fahrenheit.\n
Arrange the cooked filling in the cake pan.\n
Put the second crust over the filling and seal the sides.\n
Create holes on the secondary crust using a fork. This will serve as exhaust vents that will prevent the crust from deforming.\n
Bake for 45 to 55 minutes or until the color turns golden brown. Note: Baking time may vary; make sure to check the color of the crust to determine if baking is complete.\n
Let cool and serve. Share and enjoy!'),
('Bulalo', 'Ingredients:\n2 lbs beef shank\n
1/2 cabbage whole leaf individually detached\n
1 bundle bok choy\n
2 cobs corn each cut into 3 parts\n
2 Tablespoons whole peppercorn\n
1/2 cup green onions cut unto 1 1/2 inch pieces\n
1 onion\n
34 ounces water\n
fish sauce to taste optional\n', 'Instruction:\nIn a big cooking pot, pour in water and bring to a boil\n
Put-in the beef shank followed by the onion and whole pepper corn then simmer for 1.5 hours (30 mins if using a pressure cooker) or until meat is tender.\n
Add the corn and simmer for another 10 minutes\n
Add the fish sauce,cabbage, pechay, and green onion (onion leeks)\n
Serve hot. Share and Enjoy!'),
('Inasal', 'Ingredients:\n5 pieces chicken leg quarter\n
Marinade\n
4 tablespoons Knorr Liquid Seasoning\n
5 thumbs ginger crushed\n
6 cloves garlic crushed\n
1/2 cup white vinegar\n
2 cups lemon or lime soda\n
2 stalks lemongrass\n
Basting Sauce\n
1\4 cup annatto seeds\n
4 tablespoons cooking oil\n
1\4 teaspoon turmeric powder\n
1\2 cup margarine\n
1\2 piece lime\n', 'Instructions:\nChop the lemongrass and crush. Combine all marinade ingredients in a large bowl. Stir and let it stay for 10 minutes.\n
Arrange chicken in large resealable bags. Use more bags if needed. Pour marinade into each bag equally. Push the air out of the bag and seal. Marinate overnight inside the refrigerator.\n
Prepare the basting sauce by making annatto oil. Combine annatto seeds and 4 tablespoons cooking oil in a saucepan. Heat and continue to cook until the oil sizzles. Turn the heat off and stir until the oil turns red. Filter the oil from the seed.\n
Combine annato oil with margarine, turmeric powder, and lime. You may also add some salt preferred.\n
Heat-up the grill. Start grilling the chicken pieces for 2 minutes, and then turnover to grill the opposite side. Brush basting sauce everytime the chicken is flipped. Do this using medium heat to prevent the skin from burning. If the heat is uncontrollable, remove skin before grilling to prevent it from burning. Note: The chicken is cooked when the internal temperature is at least 165F.\n
Arrange your chicken inasal on a plate and serve with your favorite dipping sauce. Share and enjoy!\n'),
('Kare-Kare', 'Ingredients:\n3 lbs oxtail cut in 2 inch slices you an also use tripe or beef slices\n
1 piece small banana flower bud sliced\n
1 bundle pechay or bok choy\n
1 bundle string beans cut into 2 inch slices\n
4 pieces eggplants sliced\n
1 cup ground peanuts\n
1/2 cup peanut butter\n
1/2 cup shrimp paste\n
34 Ounces water about 1 Liter\n
1/2 cup annatto seeds soaked in a cup of water\n
1/2 cup toasted ground rice\n
1 tbsp garlic minced\n
1 piece onion chopped\n
salt and pepper\n', 'Instructions:\nIn a large pot, bring the water to a boil\n
Put in the oxtail followed by the onions and simmer for 2.5 to 3 hrs or until tender (35 minutes if using a pressure cooker)\n
Once the meat is tender, add the ground peanuts, peanut butter, and coloring (water from the annatto seed mixture) and simmer for 5 to 7 minutes\n
Add the toasted ground rice and simmer for 5 minutes\n
On a separate pan, saute the garlic then add the banana flower, eggplant, and string beans and cook for 5 minutes\n
Transfer the cooked vegetables to the large pot (where the rest of the ingredients are)\n
Add salt and pepper to taste\n
Serve hot with shrimp paste. Enjoy!\n'),
('Laing', 'Ingredients:\n4 ounces dried taro leaves\n
2 packs Knorr Ginataang Gulay Recipe Mix 40 grams each\n
1/2 lb pork sliced into 1/4 inch thick pieces\n
5 pieces Thai chili pepper\n
5 cloves garlic crushed\n
2 thumbs ginger crushed\n
1 piece onion sliced into thin strips\n
5 cups water\n', 'Instructions:\nPrepare the gata by combining Knorr Ginataang Gulay Recipe Mix with 5 cups water. Stir until the powder completely dilutes.\n
Arrange pork, garlic, onion, and ginger in a pot. Pour 3 and 1\2 cups gata. Put on a stovetop and apply heat. Continue to cook for 10 minutes after the liquid boils.\n
Add dried taro leaves. Cover the pot and continue to cook until the liquid is almost gone.\n
Add chili peppers and then pour remaining coconut milk. Stir and continue to cook until the liquid completely evaporates.\n
Transfer to a serving plate. Serve with rice!\n
Share and enjoy!\n
'),
('Lechon', 'Ingredients:\n5 lbs. pork belly whole slab\n
6 tablespoons Knorr SavorRich Pork Seasoning\n
1/2 cup soy sauce\n
1 piece onion\n
3 heads garlic\n
2 bunches scallions\n
3 stalks lemongrass\n
1/2 cup cooking oil\n', 'Instructions:\nRub 5 tablespoons Knorr SavorRich on the meat part of the pork. Spread evenly. Turn the pork over and rub the remaining SavorRich and soy sauce on the skin of the pork. Let it marinate for 30 minutes.\n
Preheat oven to 350F.\n
Chop the scallion, onion, and garlic. Crush the lemon grass and slice into pieces. Place all the garlic and onion over the belly. Add scallion and lemongrass. Roll the belly and secure by tying kitchen twine.\n
Rub oil all over the belly roll. Pour 4 cups of water in a roasting pan and put remaining scallions and lemongrass. Arrange a roasting rack over the pan and place the rolled belly on the rack. Roast for 1 hour.\n
Prepare the basting sauce by combining 2 tablespoons soy sauce and ¼ cup oil. Mix well. Brush all over the pork.\n
Increase the heat to 360F. Continue to roast for another hour. Note: add more water on the pan if needed.\n
Increase the heat to 370F. Brush with basting sauce. Roast for 1 hour more.\n
Increase heat to 400F. Continue to roast until the skin gets very crispy. Remove from the oven and let the pork belly cool down.\n
Make the dipping sauce by combining all the sauce ingredients as listed above. Microwave for 30 seconds.\n
Remove the twine from the belly roll and chop into serving pieces. Serve with spicy vinegar dip.\n
Share and enjoy!\n'),
('Pancit Palabok', 'Ingredients:\n500 grams rice noodles bihon\n
Sauce Ingredients\n
2 tbsp cooking oil\n
1/2 lb ground pork\n
1 tbsp anatto powder\n
3 cups pork broth\n
1 piece shrimp bouillon\n
6 tablespoons all-purpose flour\n
2 tbsp fish sauce\n
1/2 tsp ground black pepper\n
Topping Ingredients\n
1 cup pork belly boiled and sliced thinly into small pieces\n
4 ounces firm tofu fried and sliced into cubes\n
1/2 cup tinapa flakes smoked fish\n
1/2 cup chicharon pounded\n
2 hard boiled eggs sliced\n
1/2 cup cooked shrimps boiled or steamed\n
1/4 cup green onion or scallions finely chopped\n
3 Tablespoons toasted garlic\n
2 lemons sliced (or 6 pieces calamansi)\n', 'Instructions:\nSoak the rice noodles in water for about 15 minutes. Drain and set aside.\n
Cook the sauce by heating a saucepan. Pour-in the cooking oil.\n
When the oil is hot enough, put-in the ground pork and cook for about 5 to 7 minutes\n
Dilute the annato powder in pork broth then pour the mixture in the saucepan. Bring to a boil (If you are using anatto seeds, soak them first in 3 tbsp water to bring-out the color)\n
Add the shrimp cube and stir and simmer for 3 minutes\n
Add the flour gradually while stirring.\n
Add the fish sauce and ground black pepper then simmer until sauce becomes thick. Set aside.\n
Meanwhile, boil enough water in a pot.\n
Place the soaked noodles in a strainer (use metal or bamboo strainer) then submerge the strainer in the boiling water for about a minute or until the noodles are cooked. (make sure that the noodles are still firm)\n
Remove the strainer from the pot and drain the liquid from the noodles.\n
Place the noodles in the serving plate.\n
Pour the sauce on top of the noodles then arrange the toppings over the sauce.\n
Serve with a slice of lemon or calamansi. Share and enjoy!\n'),
('Pinakbet', 'Ingredients:\n4 pieces round eggplant cut in half\n
2 pieces small bitter melon ampalaya, quartered\n
1/2 bundle string beans cut into 2 inch length\n
1 piece sweet potato kamote, quartered\n
8 pieces okra\n
1 piece tomato cubed\n
1 piece onion cubed\n
1 and 1/2 cup water\n
1 lb bagnet\n
1/4 cup Anchovy sauce bagoong isda\n', 'Instructions:\nIn a large pan, place water let boil\n
Put in the anchovy sauce and wait for the mixture to boil once more\n
Add-in the vegetables starting with the sweet potato then put-in the okra, bitter melon, eggplant, string beans, tomato, and onion and simmer for 15 minutes\n
Add the bagnet or lechon kawali (cooking procedure available in the recipe section) and simmer for 5 minutes\n
Serve hot. Share and Enjoy!\n'),
('Sinigang', 'Ingredients:\n2 lbs pork belly or buto-buto\n
1 bunch spinach or kang-kong\n
3 tablespoons fish sauce\n
1/2 pieces string beans sitaw, cut in 2 inch length\n
2 pieces tomato quartered\n
3 pieces chili or banana pepper\n
1 tablespoons cooking oil\n
2 quarts water\n
1 piece onion sliced\n
2 pieces taro gabi, quartered\n
1 pack sinigang mix good for 2 liters water\n', 'Instructions:\nHeat the pot and put-in the cooking oil\n
Saute the onion until its layers separate from each other\n
Add the pork belly and cook until outer part turns light brown\n
Put-in the fish sauce and mix with the ingredients\n
Pour the water and bring to a boil\n
Add the taro and tomatoes then simmer for 40 minutes or until pork is tender\n
Put-in the sinigang mix and chili\n
Add the string beans (and other vegetables if there are any) and simmer for 5 to 8 minutes\n
Put-in the spinach, turn off the heat, and cover the pot. Let the spinach cook using the remaining heat in the pot.\n
Serve hot. Share and enjoy!\n'),
('Sisig', 'Ingredients:\n1 lb. pig ears\n
1 1/2 lb pork belly\n
1 piece onion minced\n
3 tablespoons soy sauce\n
1/4 teaspoon ground black pepper\n
1 knob ginger minced (optional)\n
3 tablespoons chili flakes\n
1/2 teaspoon garlic powder\n
1 piece lemon or 3 to 5 pieces calamansi\n
1/2 cup butter or margarine\n
1/4 lb chicken liver\n
6 cups water\n
3 tablespoons mayonnaise\n
1/2 teaspoon salt\n
1 piece egg (optional)\n', 'Instructions:\nPour the water in a pan and bring to a boil Add salt and pepper.\n
Put-in the pig\'s ears and pork belly then simmer for 40 minutes to 1 hour (or until tender).\n
Remove the boiled ingredients from the pot then drain excess water\n
Grill the boiled pig ears and pork belly until done\n
Chop the pig ears and pork belly into fine pieces\n
In a wide pan, melt the butter or margarine. Add the onions. Cook until onions are soft.\n
Put-in the ginger and cook for 2 minutes\n
Add the chicken liver. Crush the chicken liver while cooking it in the pan.\n
Add the chopped pig ears and pork belly. Cook for 10 to 12 minutes\n
Put-in the soy sauce, garlic powder, and chili. Mix well\n
Add salt and pepper to taste\n
Put-in the mayonnaise and mix with the other ingredients\n
Transfer to a serving plate. Top with chopped green onions and raw egg.\n
Serve hot. Share and Enjoy (add the lemon or calamansi before eating)\n'),
('Tapa', 'Ingredients:\n1 1/2 lb beef sirloin thinly sliced\n
5 tablespoons soy sauce\n
3 tbsp minced garlic or 1 tablespoon garlic powder\n
2 tbsp sugar\n
1/4 teaspoon salt\n
1/4 teaspoon ground black pepper\n', 'Instructions:\nIn a container, combine soy sauce, garlic, salt, pepper, and sugar and mix well. Set aside\n
Place the beef in the clear plastic bag\n
Pour-in the the mixed seasonings in the clear plastic bag with meat and mix well\n
Place inside the refrigerator and marinate for a minimum of 12 hours\n
In a pan, place 1 cup water and bring to a boil\n
Add 3 tbsp of cooking oil\n
Put-in the marinated beef tapa and cook until the water evaporates.\n'),
('Pancit Batil Patung', 'Ingredients:\n6 oz. minced beef or carabeef\n
12 oz. fresh Miki noodles\n
3 to 4 oz. pork liver sliced\n
1 medium red onion cubed\n
1 1/2 cup mung bean sprouts\n
3/4 cups chopped green onions\n
1 cup shredded cabbage\n
1 cup carrot julienne\n
3 tablepespoons soy sauce\n
1 egg\n
1/4 teaspoon ground black pepper\n
6 oz. lechon carajay chopped\n
3 tablespoons cooking oil\n
Batil:\n
1 lb. beef bones with meat\n
1 beef cube\n
1 egg\n
6 to 8 cups water\n
1 stalk celery chopped\n
1 medium carrot cubed\n
1 small onion cubed\n','Instructions:\nPrepare the stock (or batil) by boiling water in a cooking pot. Add the beef bones. Let boil for 5 minutes.\n
Hold the chopped celery, carrot, and onion together using a cheese cloth and secure using a kithen thread. This will be the mirepoix. Add the mirepoix in the cooking pot and let boil.\n
Add the beef cube. Continue to boil in low heat for 3 hours or until the beef gets tender. You may add more water if needed. Once the stock is ready, set aside.\n
Heat the cooking oil in a wide pan or wok. Saute the onion until soft.\n
Add the minced beef. Saute for 3 to 5 minutes.\n
Stir-in the sliced liver. Saute for 3 minutes.\n
Add the mung bean sprouts, green onion, cabbage, and carrots. Continue to saute for 2 to 3 minutes.\n
Scoop-in 4 to 5 cups of beef stock. Let boil.\n
Push the meat and vegetables on one side of the pan. Arrange the Miki noodles on the other side. Toss the noodles while cooking. Add soy sauce and ground black pepper. cook for 2 to 3 minutes.\n
Push the noodles on one side to create an opening. Crack one egg and gently let it slide into the broth. Poach until cooked. Remove the poached egg and set aside.\n
Remove the noodles from the pan and arrange in a plate.\n
Scoop out the remaining stock and place in a small sauce pan. Turn off the heat and transfer the cooked meat and vegetables in a clean plate. Set aside.\n
Meanwhile, heat the saucepan with the stock from the pan. Once it starts to boil, crack a piece of egg and add it to the pot. Quickly stir and continue to cook while constantly stirring for 1 to 2 minutes or until an egg drop soup consistency is formed. Transfer to a bowl.\n
Start to assemble the Pancit Batil Patung by topping the miki noodles with poached egg. Add the sautéed meat and vegetables over the egg and top with lechon carajay.\n
Serve with a bowl of batil on the side along with a dip that consists of chopped onion, soy sauce, and vinegar.\n
Share and enjoy!\n'),
('Ginataang Alimasag','Ingredients:\n3 lbs blue crabs Alimasag\n
2 tbsp shrimp paste\n
1 tbsp fish sauce\n
1 tsp garlic minced\n
1 piece onion minced\n
1 thumb ginger cut into thin strips\n
3 tbsp cooking oil\n
4 cups coconut milk\n
1/2 tsp ground black pepper\n
1 bunch fresh spinach\n
6 pieces Thai chili\n','Ingredients:\nIn a large pot, sauté the garlic, onion, and ginger\n
Add the ground black pepper and coconut milk then bring to a boil\n
Put-in the shrimp paste and fish sauce and cook until the coconut milk\'s texture is thick and natural oil comes out of it (approximately 20 ++ minutes)\n
Add the Thai chili and simmer for 5 minutes\n
Put the crabs in the pot and mix until evenly covered with coconut milk. Simmer for 5 to 20 minutes. (Note: If crabs were steamed prior to cooking, 5 to 8 minutes is enough)\n
Add the spinach and simmer for 5 minutes\n
Serve hot. Share and Enjoy!\n');



ALTER TABLE `foodrecipe`
 ADD PRIMARY KEY(`name`);

ALTER TABLE `foodcategory`
  ADD PRIMARY KEY (`name`);


ALTER TABLE `fooddesc`
  ADD PRIMARY KEY (`name`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
