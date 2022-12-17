VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0RelationshipSc = "Crush"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 22
VAR NPC1OccupationSc = "HigherInPosition"
VAR NPC2OccupationSc = "Colleague"

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0PopularityCh = 0
VAR NPC2HappinessCh = 0
VAR NPC2RelationshipCh = 0
VAR NPC0SympathyCh = 0

%FullName:NPC:1% reminds me of %Pron:1:2% party coming up but it's the same day I work.
What do I do?
* [Just go into work and skip the party]
    -> res1
* [Ask %FullName:NPC:3% to work my shift.]
    -> res2
* [Put a note up at work asking anyone to take my shift.]
    -> res3
* [Just skip work and go to the party]
    -> res4

=== res1 === 
%FullName:NPC:1% is mad at me but my boss %FullName:NPC:2% is happy with the work I do.
~TextForLog = "I make good money working. And I do a good job so %FullName:NPC:2% is happy with me. So, there's that. However, %FullName:NPC:1% is so angry at me. I feel badly I forgot about %Pron:1:2% party but I felt like it was probably too late to do something about it. Plus, I could probably use the money."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%90%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:3% works it and I get to go to the party and have a great time.
~TextForLog = "%FullName:NPC:3% is really grateful I asked %Pron:3:2% because %Pron:3:1% ends up making a lot of money. And I'm happy to go to the party and have a great time with %FullName:NPC:1%. Things seem great between us."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC2HappinessCh = "%ValueRef:0:+%"
~NPC2RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I go to the party assuming my shift is covered but no one saw the note and now my boss %FullName:NPC:2% is mad at me.
~TextForLog = "I'm having a good time with %FullName:NPC:1% at the party at first but then my boss %FullName:NPC:2% texts me asking where I am. I find out later no one took my shift because no one saw the note. I try explaining to %FullName:NPC:2% but %Pron:2:1% is so mad at me."
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
I have a great time at the party, until I find out that I got fired.
~TextForLog = "%FullName:NPC:2% fired me for not showing up to work. I thought maybe I might just get yelled at for skipping one day, not get fired! Well, the party was fun at first. %FullName:NPC:1% finds out I got fired and feels badly that it was all over %Pron:1:3% party."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:1:-%"
~NPC1RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END
