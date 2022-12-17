VAR StoryTittle = ""
VAR StoryQuestion = "What should we do?"
VAR StoryCategory = "Family"
VAR TextForLog = ""

VAR Character0OccupationSc = "Retirement"
VAR Character0MinAgeSc = 60
VAR NPC0RelativesSc = "Kid"
VAR NPC0MinAgeSc = 30
VAR NPC0MaxAgeSc = 40

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC0SympathyCh = 0

My kid is in town visiting me and wants to do some outdoor activity today since it's nice.
What should we do?
* [Go golfing]
    -> res1
* [Play tennis]
    -> res2
* [Go canoeing ]
    -> res3

=== res1 === 
We have a great time golfing and we both end up doing very well!
~TextForLog = "Not only was golfing fun and we bond a lot, but %FullName:NPC:1% got some sun and tad bit of exercise in from walking all over the greens. We even did a little running and jogging from one hole to another for fun. It was an overall great day, I'm so glad we decided on golf!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We play for just a bit before I trip and fall and seriously hurt my hip.
~TextForLog = "%FullName:NPC:1% has to take me to the hospital I hurt my hip so badly. It turns out it was a fracture. Just great. We were just trying to have a nice time on the tennis court and I have to go and get seriously injured. But %FullName:NPC:1% does such a great job taking care of me."
~Character0HealthCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
~NPC0SympathyCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
We end up arguing almost the entire time we are out in the canoe
~TextForLog = "This is an activity we never did before and we will never do again. %FullName:NPC:1% and I kept trying to get the other to go about everything our way and it just resulted in a lot of arguing and a lot of confusion over where we were even heading to. I am so annoyed, %Pron:1:1% can be so stubborn sometimes. I'm also quite sore after that whole trip!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
