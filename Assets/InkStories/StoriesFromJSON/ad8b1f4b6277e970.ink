VAR StoryTittle = ""
VAR StoryQuestion = "When we get there we see three floating orbs. What do we do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "Colleague"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 22

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WisdomCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0AppearanceCh = 0
VAR NPC0SympathyCh = 0

Late at night %FullName:NPC:1% and I have to go to the janitor's closet in the backroom to get supplies.
When we get there we see three floating orbs. What do we do?
* [Don't move at all.]
    -> res1
* [Run away.]
    -> res2

=== res1 === 
We stand still and the orbs gently pass through us and we actually end up feeling phenomenal.
~TextForLog = "We just stayed put and watched as the orbs slowly moved towards us and floated right through us. Which was unnerving at first but then it was the strangest thing, we both instantly felt phenomenal! %FullName:NPC:1% had a bad knee that didn't hurt anymore! And I had a headache that just went away! Those orbs... they were supernatural... I'm sure of it!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We take off running and these orbs chase us and fly into us, knocking us out and we both awake in the hospital.
~TextForLog = "Not only did these orbs hit us and knock us out... but they did something else to us. Me and %FullName:NPC:1% both awoke in the hospital, with cuts and bruises all over, sick to our stomachs and vomiting and with second degree burns on our faces and necks. What in the world were those things?? I will never run away from something like that again."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:1:-%"
~Character0HealthCh = "%ValueRef:1:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
