VAR StoryTittle = ""
VAR StoryQuestion = "How do you defend a castle?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid:PrimarySchool"
VAR Character0MinAgeSc = 3
VAR Character0MaxAgeSc = 5
VAR NPC0RelativesSc = "Sibling"
VAR NPC1RelativesSc = "Parent"
VAR NPC1GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0IntelligenceCh = 0

My brother, %FirstName:NPC:1%, keeps wrecking my papier mache castle. He either globs it with the paints I'm using, or grabs it with his bare hands. He's only tiny, but it's still driving me mad.
How do you defend a castle?
* [Tell Mom - she hates us squabbling, but at least she can do something!]
    -> res1
* [Try to stop %FirstName:NPC:1% myself. My mom doesn't need the hassle. ]
    -> res2
* [Tell him off. Little kids need discipline. ]
    -> res3

=== res1 === 
My mom wasn't best pleased - she's always annoyed when she sees us squabbling and never seems to care whose fault it is. %FirstName:NPC:1% started crying. At least I can get on with my project.  
~TextForLog = "I suppose there's not much point getting your parents involved in an everyday spat with your little brother. Still, at least I can carry on making my awesome castle model. "
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I tried to talk to him first, but that was not going to work. Instead, I erected a barricade more impregnable than the castle itself. I also lent him some of my toys. Off he went! Everyone's happy!
~TextForLog = "I took control of my own problem today - my little brother was wrecking my stuff, so I distracted him away, lent him some toys, and he was happy. My mom just loved that we seemed to be getting on. I guess we kind of were, too!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I hardly even started yelling that loud, and %FirstName:NPC:1% just burst into tears. I heard Mom coming and tried to calm him down, but I swear he sensed advantage. Now my mom is super mad with me. 
~TextForLog = "Little brothers are the worst, but maybe older siblings aren't much better. I should never have told my little brother off like that, since he was only trying to play with my papier mache castle. I guess I've learnt to be a little more patient. "
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
