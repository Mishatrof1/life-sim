VAR StoryTittle = ""
VAR StoryQuestion = "When I use the sink, the water sprays out all over my crotch. What should I do?"
VAR StoryCategory = "Pink"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 18
VAR Character0MaxAgeSc = 35
VAR NPC0RelationshipSc = "Crush"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 18
VAR NPC0MaxAgeSc = 35

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0PopularityCh = 0
VAR NPC0SympathyCh = 0
VAR Character0EnduranceCh = 0
VAR Character0WealthCh = 0

I'm on a date with %FullName:NPC:1% and I use the bathroom.
When I use the sink, the water sprays out all over my crotch. What should I do?
* [Tie my shirt around my waist]
    -> res1
* [Don't do anything different]
    -> res2
* [Wet my entire pants with water so there isn't a wet spot only on my crotch]
    -> res3
* [Climb out the bathroom window, run to a store for another pair of pants.]
    -> res4

=== res1 === 
It's a nice restaurant so %FullName:NPC:1% is embarrassed that I dressed myself this way.
~TextForLog = "%FullName:NPC:1% is embarrassed that %Pron:1:1% is at a table with me in this nice restaurant since I have my shirt tied around my waist. I explained to %Pron:1:2% the situation and I was trying to not embarrass myself but %Pron:1:1% isn't having any of it and ends the date early."
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
So many people in the restaurant laugh at me but %FullName:NPC:1% understands it was from the sink.
~TextForLog = "I'm just happy that %FullName:NPC:1% understands and I am just trying to ignore everyone else in the restaurant who is screaming out that I look like I wet myself. But it's hard to ignore them."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I exit the bathroom and at first no one notices until I sit down and water is leaking everywhere.
~TextForLog = "%FullName:NPC:1% is mortified as people start filming me and I end up being all over the internet because I emerged from the bathroom with soaking wet pants. Those videos get too many views. And I try to explain to %FullName:NPC:1% but %Pron:1:1% is so embarrassed and wants to leave."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res4 === 
I ran to a nearby store, purchased another pair of pants and returned with those.
~TextForLog = "%FullName:NPC:1% immediately notices the new pants so I have to explain what happened to %Pron:1:2% and %Pron:1:1% finds this hilarious and can't stop laughing and we end up having a great rest of the night."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-50%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
