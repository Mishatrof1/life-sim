VAR StoryTittle = ""
VAR StoryQuestion = "What do I give him?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR NPC0RelativesSc = "Parent:StepParent"
VAR NPC0GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0IntelligenceCh = 0

My father is working on a project in the garage and needs my help. He says he needs to get a nail into the wall.
What do I give him?
* [Hand him a hammer]
    -> res1
* [Hand him pliers]
    -> res2
* [Hand him a screwdriver]
    -> res3
* [Hand him the whole toolbox]
    -> res4

=== res1 === 
He thanks me for the hammer and is glad I knew the right tool that he needed. He shows me what he’s working on and we bond.
~TextForLog = "My father and I have a great time bonding while he worked on his project and it was a great way to spend a few hours."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
He gets mad at me because it’s the wrong tool and tells me I need to stay and watch him work to learn a thing or two.
~TextForLog = "My father definitely got annoyed with me and I got annoyed with him, but I did actually learn a bit about what he was doing. So, it wasn’t a total loss of a day."
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
He sighs because it’s the wrong tooL. He is annoyed but tells me to go back in the house. I go in and watch TV.
~TextForLog = "My father was irritated I could tell, but it’s not my fault I don’t know about this stuff. Anyway, I was happy to not have to help him and be able to watch TV."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
He laughs and tells me he needs a hammer and then decides to teach me some things about what he’s doing.
~TextForLog = "My father and I had a good time actually even though I had no idea what he was doing at first. But he taught me a lot!"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
