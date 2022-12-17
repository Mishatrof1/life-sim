VAR StoryTittle = ""
VAR StoryQuestion = "I think I hear someone whispering my name. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 22
VAR Character0MaxAgeSc = 50
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 22
VAR NPC0MaxAgeSc = 50

VAR Character0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0
VAR Character0WisdomCh = 0
VAR NPC0SympathyCh = 0

I am home alone and the lights go out in the house.
I think I hear someone whispering my name. What should I do?
* [Leave the house!]
    -> res1
* [Light a candle]
    -> res2

=== res1 === 
I go to an all night coffee place until %FullName:NPC:1% gets home, then I return.
~TextForLog = "%FullName:NPC:1% is annoyed that I just left because the lights went out and didn't call and let %Pron:1:2% know or anything. I was just thankful to get out of that house. Something weird was happening. I honestly felt like it was haunted in that moment. When I get back, the lights come back on, which is very strange."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
I light a candle and see a face appear suddenly in the light and it scares me and I faint.
~TextForLog = "%FullName:NPC:1% comes home and finds me unconscious and wakes me up. I burned myself with the candle and hurt my back when I fell. I tell %Pron:1:2% exactly what happened and we both agree that we think it was a ghost, considering all the doors and windows were locked, no one could have gotten in there with me."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:1:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
