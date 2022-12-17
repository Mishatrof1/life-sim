VAR StoryTittle = ""
VAR StoryQuestion = "Which jacket should I wear?"
VAR StoryCategory = "Cyan"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18
VAR NPC0RelationshipSc = "Crush"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 13
VAR NPC0MaxAgeSc = 18

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0PopularityCh = 0

I'm going on a date with %FullName:NPC:1%.
Which jacket should I wear?
* [My red jacket]
    -> res1
* [My brown jacket]
    -> res2

=== res1 === 
My red jacket had $40 in it from the last time I wore it, so we use that to make our meal extravagant.
~TextForLog = "That was like finding a free $40 which was great. I was going to be skimping on dinner but with the extra money I was able to get us everything we wanted plus a big lavish dessert after the meal. And %FullName:NPC:1% loved it!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My brown jacket has a hole in it and I look like a mess now.
~TextForLog = "%FullName:NPC:1% clearly did not like that I showed up with a hole in my jacket. I do look like a mess. Because of this %Pron:1:1% wants to cute the date short and go home. So, I could tell right then and there that the date wasn't going well. And it was even more apparent when %Pron:1:1% told all %Pron:1:2% friends too."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
