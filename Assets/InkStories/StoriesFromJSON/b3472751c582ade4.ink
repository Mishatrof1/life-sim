VAR StoryTittle = ""
VAR StoryQuestion = "Up ahead we see something about 10 feet tall walking through the trees. What should we do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 17
VAR Character0MaxAgeSc = 30
VAR NPC0RelationshipSc = "Friend"
VAR NPC0MinAgeSc = 17
VAR NPC0MaxAgeSc = 30

VAR Character0HappinessCh = 0
VAR Character0WisdomCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0

Me and %FullName:NPC:1% are hiking deep in the woods.
Up ahead we see something about 10 feet tall walking through the trees. What should we do?
* [Approach and try to film it with our phones]
    -> res1
* [Run back the direction we came from.]
    -> res2
* [Walk slowly in another direction]
    -> res3

=== res1 === 
We get close but our phones get all screwy and shut down but we get a good glimpse of this thing before it vanishes.
~TextForLog = "Me and %FullName:NPC:1% both know we saw some giant being that we'd never seen before and we literally saw it disappear into thin air. We can't believe it and something happened with our phones, as if this being wouldn't let us film it. We tell our friends and no one believes us and thinks we're crazy, but we know we saw something... different."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
This thing hears us running and roars at us and we trip and fall on some rocks.
~TextForLog = "We forgot the way we came from was littered with rocks and stones and when this thing heard us running and roared it scared us so badly we tripped and fell and got all scraped up. It sounded like it was pursuing us so we got up and kept running out of there and eventually made it out of the woods. That was scary!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
We walk off slowly in another direction but the thing hears us and roars and we end up taking off.
~TextForLog = "This thing still hears us and roared so we took off running, but we realized after a bit that we couldn't hear it anymore so we stop running. We end up being way off the path and have to hike awhile before we get back to where we need to be. But we both know... that was not something we had ever seen or heard before. Something... otherworldly."
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
