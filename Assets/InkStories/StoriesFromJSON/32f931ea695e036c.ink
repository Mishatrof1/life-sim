VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 22
VAR Character0MaxAgeSc = 55
VAR NPC0RelationshipSc = "Partner"
VAR NPC0MinAgeSc = 22
VAR NPC0MaxAgeSc = 55

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

I'm leaving work and %FullName:NPC:1% calls me and asks me to get food for dinner.
What should I do?
* [Stop to get groceries so we can cook dinner]
    -> res1
* [Get fast food take out]
    -> res2
* [Get food from a nice restaurant]
    -> res3
* [Get pre made food from grocery store]
    -> res4

=== res1 === 
I bring groceries home and we cook together and actually have a great time doing so.
~TextForLog = "Me and %FulName:NPC:1% love to cook together, we always have fun and tend to create some amazing dishes together. This turned out to be a really fun night and we had a delicious and healthy dinner."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-25%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
Fast food take out is quick and cheap and fills us up... but slows us down too.
~TextForLog = "%FullName:NPC:1% eat the fast food and get completely filled up on it, and as always, we then start to feel a little slowed down and weighed down. Oh ell, it's the best option for something fast and cheap when we don't want to spend a lot of time making something and don't want to spend a lot of money."
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-10%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% loves that I went out of my way to get us a nice meal.
~TextForLog = "This is one of our favorite restaurants and it is a bit out of the way but %FullName:NPC:1% really appreciated the gesture from me. And we both just absolutely love this food. I think it was well worth the extra time and money. And we reminisce over one of our first dates here and have an amazing night."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-50%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res4 === 
%FullName:NPC:1% is annoyed that I didn't just get something better at the grocery store.
~TextForLog = "%FullName:NPC:1% doesn't understand why I didn't get groceries if I was at the grocery store but I felt like this made more sense because it was quicker and cheaper. We didn't have to make anything, it's all pre made. %Pron:1:1% is annoyed with my decision. And to be honest, the food wasn't so great. So, now I'm sort of annoyed with myself too."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-15%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
