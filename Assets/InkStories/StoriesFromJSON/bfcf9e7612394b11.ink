VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelativesSc = "Kid:AdoptedKid"
VAR NPC0MinAgeSc = 6
VAR NPC0MaxAgeSc = 15
VAR NPC1OccupationSc = "HigherInPosition"

VAR Character0HealthCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR NPC1RelationshipCh = 0

My kid wants to take the day off from school.
What should I do?
* [Tell %Pron:1:2% I’ll take off from work and we will go to the beach.]
    -> res1
* [Tell %Pron:1:2% I’ll take off from work and we will go to a basketball game]
    -> res2
* [Tell %Pron:1:2% %Pron:1:1% has to go to school and I still go to work.]
    -> res3
* [Tell %Pron:1:2% %Pron:1:1% can come in to work with me and we’ll leave early and go paintballing.]
    -> res4

=== res1 === 
We have a nice, relaxing day off at the beach together. I fall behind in work and also I do get sunburned.
~TextForLog = "This was a relaxing day, it was nice to take a day off from work even if I fell behind a little bit. My kid and I bonded, but I am going to have to work extra to catch up at work, plus, I got really sunburned. Oh, the pain!"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We go to the game and have a fantastic time but we end up on TV and my boss sees and is livid I lied and said I was sick.
~TextForLog = "This was a fantastic day, watching the game and hanging out with my kid, that is until my boss spotted us on TV. After saying I was sick, wow am I in trouble now."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
My kid gets annoyed with me because %Pron:1:1% feels like %Pron:1:1% deserves a day off, I go into work per usual.
~TextForLog = "My kid is annoyed I didn’t let %Pron:1:2% take a day off but %Pron:1:1% really should be in school, plus I really wanted to get ahead in work and get a lot of stuff done, which I did."
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
My kid enjoys coming into work with me, I get enough work done and we have a blast playing paintball!
~TextForLog = "My kid was happy to get a day off, even if it meant spending half of it with me at work. And then we were able to skip out early and play paintball! It was great but I am in bad shape now with so many bruises!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
