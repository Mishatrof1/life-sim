VAR StoryTittle = ""
VAR StoryQuestion = "What do I get?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MaxAgeSc = 16
VAR NPC0RelativesSc = "Parent:StepParent"
VAR NPC0GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0

My father gives me $30 to go buy lunch for the family.
What do I get?
* [Spend the $30 at the taco place]
    -> res1
* [Spend the $30 at the popular French restaurant]
    -> res2
* [Spend $20 on sandwiches, return the $10]
    -> res3
* [Spend $20 on sandwiches, keep the $10]
    -> res4

=== res1 === 
My father is proud I made a good decision and got a lot of food for the money, he gives me $10 to keep.
~TextForLog = "Hey, my father was proud of me for making a good economical decision, we had plenty to eat AND I got some extra money from him! I might always choose tacos now."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%10%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My father is upset I wasted the money and brought home barely any food. But it’s so delicious.
~TextForLog = "That French food was so good, but we didn’t quite have enough to fill us all up, I definitely see why my father got so mad at me. Whoops! At least it was tasty food."
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
My father is proud I spent the money wisely and returned the money. But I got food poisoning from my sandwich.
~TextForLog = "My father was happy with my decision on lunch and I guess I did feel responsible bringing the money back. But I don’t feel so hot after that sandwich..."
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
My father doesn’t say it, but he knows I kept money and is upset. Also he gets food poisoning from his sandwich and I feel guilty.
~TextForLog = "This went terribly, my father was visibly annoyed, I think he knew I kept extra money and he got sick! I feel like it’s all my fault... at least I got some extra cash I guess?"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%10%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
