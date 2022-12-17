VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "Colleague"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 22
VAR NPC1OccupationSc = "Colleague"
VAR NPC1GenderSc = "Same"
VAR NPC2OccupationSc = "Colleague"
VAR NPC2GenderSc = "Same"

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC2HappinessCh = 0
VAR NPC2RelationshipCh = 0

%FullName:NPC:1% is working Saturday and I am not, but I want to try to ask %Pron:1:2% out that day.
What should I do?
* [Ask %FullName:NPC:2% if I can take %Pron:2:3% Saturday shift.]
    -> res1
* [Ask %FullName:NPC:3% if I can take %Pron:3:3% Saturday shift.]
    -> res2
* [Just go into work and try to ask %FullName:NPC:1% out.]
    -> res3

=== res1 === 
This shift doesn't line up with %FullName:NPC:1%'s shift and I don't get a chance to ask %Pron1:2% out.
~TextForLog = "%FullName:NPC:2% is happy I take %Pron:2:3% shift but I'm not happy when I realize this shift isn't really the same time as %FullName:NPC:1%'s shift. I get no time to work with %Pron:1:2% or talk to %Pron:1:2% and I just end up working a day I was supposed to be off as %Pron:1:1% leaves soon after I start work."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%60%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My shift lines up perfectly with %FullName:NPC:1% and I am able to ask %Pron:1:2% out.
~TextForLog = "The shift I take lines up perfectly with %FullName:NPC:1%'s shift. We have a good time working together and I eventually get an opportunity to ask %Pron:1:2% out and %Pron:1:1% says yes! We have a date tomorrow night!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%50%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC2HappinessCh = "%ValueRef:0:+%"
~NPC2RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I go into work but it winds up being so awkward, everyone is confused why I'm there, I just end up leaving.
~TextForLog = "I was trying to talk to %FullName:NPC:1% but %FullName:NPC:3% was there working with %Pron:1:2% and was making everything awkward and kept asking why I was there if I wasn't supposed to be working. I couldn't get a moment to ask %FullName:NPC:1% out so I just left. Waste of my Saturday."
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC2RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
