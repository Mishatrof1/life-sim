VAR StoryTittle = ""
VAR StoryQuestion = "What do I tell him?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelativesSc = "Parent:StepParent"
VAR NPC0GenderSc = "Male"

VAR Character0IntelligenceCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HappinessCh = 0

My father asks me what I am going to contribute from my paychecks into my retirement fund.
What do I tell him?
* [“I don’t know, I’ll figure it out.”]
    -> res1
* [“Retirement fund? I don’t need that yet.”]
    -> res2
* [“Just 3% is fine.”]
    -> res3
* [“I think probably 5% or so.”]
    -> res4

=== res1 === 
My father laughs and tells me we’ll figure it out together and he teaches me about finances.
~TextForLog = "I’m glad my father taught me so much about finances and retirement funds because I had no idea! But I might be ready to plan some big time stuff out now!"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My father is livid and tells me I absolutely need to start one and tells me I need to look into this. But I’m not going to.
~TextForLog = "My father is annoyed with me now but I don’t see the big deal. I’m still young and I am keeping more of my money I’m earning so this seems better."
~Character0IntelligenceCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
My father gets annoyed at my casual response, he tells me 3% isn’t enough and then teaches me about finances.
~TextForLog = "My father got irritated with me, which at first annoyed me too, but he actually did teach me a lot about retirement funds and I think I realized he’s just trying to help. Even when he puts me in a bad mood."
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
My father is happy with my answer. He decides to take me out for a nice dinner.
~TextForLog = "Well, I’m glad I shot for 5% because my father was happy with that and it got me a free dinner! Next time he asks I might say 10% and go for dessert!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
