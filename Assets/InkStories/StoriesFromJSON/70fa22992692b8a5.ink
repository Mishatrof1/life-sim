VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR NPC0RelationshipSc = "Crush"
VAR NPC1RelativesSc = "Sibling:StepSibling"
VAR NPC1GenderSc = "Male"

VAR NPC1RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR NPC0RelationshipCh = 0

My crush %FirstName:Npc:1% wants someone to bring a guitar to %Pron:1:3% party, I don’t have one but my brother does.
What do I do?
* [Ask to borrow his guitar]
    -> res1
* [Take his guitar without telling him]
    -> res2
* [Tell %FirstName:Npc:1% sorry, I don’t have a guitar]
    -> res3
* [Ask my brother to come with his guitar]
    -> res4

=== res1 === 
My brother says no, he won’t let me borrow it. We get in an argument, I go to the party and tell %FirstName:Npc:1% and %Pron:1:1% understands.
~TextForLog = "I guess the party was alright, but I’m really annoyed with my brother for not letting me borrow the guitar. Apparently he thinks I’m going to break it."
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FirstName:Nps:1% is thrilled with me and the party is fun but my brother and I get in a fight when I get home.
~TextForLog = "I played the guitar pretty well at %FirstName:Npc:1%’s place and %Pron:1:3% party was great! But my brother got angry I took his guitar without permission and we got into a fight."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
My brother shows up to the party with a guitar and %FirstName:Npc:1% is mad I didn’t ask him in the first place.
~TextForLog = "I can’t believe my brother showed up to the party anyway, I don’t know who invited him. But then he made me look so stupid in front of %FirstName:Npc:1%, I’m so annoyed with him!"
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
My brother joins me with his guitar and %FirstName:Npc:1% is so happy that her party goes well
~TextForLog = "I’m so glad I asked my brother to join me at the party, it went great! Everyone had a great time! And he definitely plays his guitar better than I can. And %FirstName:Npc:1% was pleased with me!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
