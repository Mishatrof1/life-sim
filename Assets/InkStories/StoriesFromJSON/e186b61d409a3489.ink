VAR StoryTittle = ""
VAR StoryQuestion = "Which bird should I feed?"
VAR StoryCategory = "Cyan"
VAR TextForLog = ""


VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0
VAR Character0PopularityCh = 0
VAR Character0WealthCh = 0
VAR Character0HappinessCh = 0

I am at the zoo at a bird exhibit and the employees tell me I can feed one of the birds.
Which bird should I feed?
* [The blue bird]
    -> res1
* [The green bird]
    -> res2
* [The yellow bird]
    -> res3

=== res1 === 
The blue bird eats the food from my hand and then starts pecking at me and biting my face!
~TextForLog = "The bird goes crazy for some reason and starts to attack me! It pecks me all over and some random person films it and posts it online and now I am a recurring GIF that people laugh about. The zoo felt badly and gave me a $100 gift card."
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
~Character0WealthCh = "%100%"
* [Ok]
-> END

=== res2 === 
The green bird comes by and eats from my hand and then it hangs out on top of me for so long singing and squawking.
~TextForLog = "Someone films the whole thing and posts the video online and it becomes a hit! This bird just wanted to hang out with me and sing and squawk while sitting on my shoulder all day long! It was so hilarious!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
The yellow bird eats the food and then is walking all around on me and grabs my wallet and flies away!
~TextForLog = "Well, that was an expensive feeding. It was fun for a moment until the bird flew off with my wallet. I had $50 in there! Plus, it was a pretty nice wallet... while it lasted."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-50%"
* [Ok]
-> END
