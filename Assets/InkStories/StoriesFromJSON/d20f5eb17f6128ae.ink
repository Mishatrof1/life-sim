VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Love:Diseases"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob:Retirement"
VAR Character0MinAgeSc = 22
VAR NPC0RelationshipSc = "Partner"
VAR NPC0MinAgeSc = 22

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0

I get home to find out that %FullName:NPC:1% is laid up in bed, sick.
What do I do?
* [Bring her medicine and a bowl of soup.]
    -> res1
* [Bring %FullName:NPC:1% a smoothie and read to %Pron:1:2%.]
    -> res2
* [Ask %FullName:NPC:1% what %Pron:1:1% wants.]
    -> res3

=== res1 === 
%FullName:NPC:1% thanks me for being so kind and tells me I can go do something else rather than stay in there and catch %Pron:1:2% sickness.
~TextForLog = "%FullName:NPC:1% is very happy I brought %Pron:1:2% medicine and a bowl of soup. It should make her feel better. %Pron:1:1% also tells me I shouldn't stay in the bedroom with %Pron:1:2% because I might get sick so I hang out in the living room and do some reading and check on %Pron:1:2% occasionally, to which %Pron:1:1% thanks me over and over and tells me I am a great caretaker."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% is so thankful that I am taking care of %Pron:1:2% and reading to %Pron:1:2% but I end up getting sick.
~TextForLog = "%FullName:NPC:1% said the smoothie was great and helped a lot and I know %Pron:1:1% was enjoying reading a new novel so I thought it would be nice to read it to %Pron:1:2%. %Pron:1:1% is so thankful and is able to relax. All was good until I started coming down with the sickness. I definitely caught what %Pron:1:1% had being in the room with %Pron:1:2% for so long."
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% tells me that %Pron:1:1% wants nothing. I go in the living room to read so I don't get sick and later find out %Pron:1:1% is mad at me!
~TextForLog = "I don't understand how %FullName:NPC:1:1% got mad at me for this! I asked what %Pron:1:1% wanted, %Pron:1:1% said nothing, so then I did nothing and left to go read! I didn't want to also get sick. Apparently, %FullName:NPC:1% feels I should've done SOMETHING for %Pron:1:2%. Then, %Pron:1:1% should've asked for something... RIGHT?"
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0IntelligenceCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END
