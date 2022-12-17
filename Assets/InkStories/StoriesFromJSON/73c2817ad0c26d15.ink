VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR NPC0RelativesSc = "Parent:StepParent"
VAR NPC0GenderSc = "Female"
VAR NPC1RelativesSc = "Parent:StepParent"
VAR NPC1GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0PopularityCh = 0

My mother’s birthday is coming up, I have $50.
What do I do?
* [Buy her a bag of her favorite cookies that cost $7.]
    -> res1
* [Buy her a nice scarf that costs $30.]
    -> res2
* [Buy her, her favorite perfume that costs $50.]
    -> res3
* [Spend $50 on a great jacket for myself, steal the perfume for her.]
    -> res4

=== res1 === 
My mother is underwhelmed by her gift and seems sad the rest of the day. She doesn’t make dinner and goes to bed early.
~TextForLog = "My mother liked the cookies and ate them all, but she was bummed out that’s all I got her. I was trying to save money for myself but now I feel like I should’ve splurged a bit more. Plus, she didn’t cook dinner and I’m starving!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-7%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res2 === 
My mother loves the scarf, she is ecstatic!
~TextForLog = "The scarf was a great choice! My mother loved it and she seemed to have a good birthday. Also, I didn’t break the bank and saved a bit of my money. Not a bad choice."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-30%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
My mother screams with joy over her perfume. My father is proud of me and takes us all out for dinner.
~TextForLog = "My mother was so happy with her perfume and my father told me I did a good job. Which was evident as he took us out for a delicious dinner! I’m glad to have given her a gift she loved, but now I’m flat broke!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-50%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
~NPC1RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res4 === 
I get caught stealing the perfume and my parents have pick me up at the store. They are livid, but I do have a sweet, new jacket.
~TextForLog = "My parents were so upset with me they didn’t talk to me the whole car ride home. It was embarrassing getting caught stealing and for my parents to find out. But hey, I’ll be the kid with a sweet, new jacket at school. One which I know the other kids are sure to love."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-50%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
