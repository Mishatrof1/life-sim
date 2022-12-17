VAR StoryTittle = ""
VAR StoryQuestion = "It's really close so we're trying to decide how to get there. What should we do?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 18
VAR Character0MaxAgeSc = 35
VAR NPC0RelationshipSc = "SignificantOther"
VAR NPC0MinAgeSc = 18
VAR NPC0MaxAgeSc = 35

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0

Me and %FullName:NPC:1% are going to go to a restaurant.
It's really close so we're trying to decide how to get there. What should we do?
* [Drive my car]
    -> res1
* [Take a cab]
    -> res2
* [Walk]
    -> res3

=== res1 === 
We drive there and have a good time, but I do have to watch how much I drink since I need to drive back.
~TextForLog = "%FullName:NPC:1% have a great time at the restaurant and get there really quickly. The beauty of driving, right? The downside? I had to drive back, which meant I had to watch how much I drank. Kind of wishing we didn't take my car just so I could have had a couple more drinks. All in all, a good night though."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-75%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We take a cab to the restaurant and back and then I don't have to worry about how much I drink which is nice.
~TextForLog = "%FullName:NPC:1% and I had a great time. I was so glad we decided on taking a cab. Sure, it cost a little more, but then I was able to have a bit more alcohol and have a great night. Not monitoring my intake of alcohol or anything. Not like I drank too much or anything! But yeah, this was an excellent night."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-115%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
Walking seemed like a good idea until we got jumped and mugged!
~TextForLog = "Our attackers jumped out of an alley and beat us pretty badly, me especially. They took off with our wallets and left us there. We had to call an ambulance and get this, %FullName:NPC:1% blames me for this! As if I should've known we may have gotten mugged! I'm sitting here in pain and %Pron:1:1% is blaming me for us getting mugged! At least my wallet didn't have too much cash in it."
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:1:-%"
~Character0WealthCh = "%-50%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END
