VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool"
VAR NPC0RelativesSc = "Parent:StepParent"
VAR NPC0GenderSc = "Male"
VAR NPC1OccupationSc = "Classmate"

VAR Character0AppearanceCh = 0
VAR Character0PopularityCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0

My father made me an appointment to get my car inspected but my acquaintance %FirstName:Npc:2% is having a pool party.
What do I do?
* [Go to the appointment, skip the pool party]
    -> res1
* [Call and cancel the appointment and go to the pool party]
    -> res2
* [Push the appointment to tomorrow and go to the pool party]
    -> res3
* [Don’t call, just go to the pool party]
    -> res4

=== res1 === 
My father is proud of me and buys me a jacket but %FirstName:Npc:2% and other kids get annoyed at me for not showing.
~TextForLog = "%FirstName:Npc:2% and other kids at the pool party got mad at me for not showing, but I feel good knowing my father is proud of me, and this jacket is a nice reward!"
~Character0AppearanceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
My dad gets upset with me but doesn’t really talk much to me when I get home, though I have fun at the pool party.
~TextForLog = "I had a great time with %FirstName:Npc:2% and everyone else but coming home and seeing my father so quiet and annoyed really made me feel awful."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
My father’s proud of me for being responsible, %FirstName:Npc:2% and other kids become closer to me but I get into an accident on the way to my rescheduled appointment.
~TextForLog = "Everyone was happy with me, my father, all the kids at the pool party, but the accident I got in the next morning ruined my mood... and my car..."
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
My father gets mad at me and grounds me when I return but I have a blast at the pool party!
~TextForLog = "Sometimes the price you have to pay for being popular is to have your father be annoyed with you and ground you. Hopefully not permanently or anything..."
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
