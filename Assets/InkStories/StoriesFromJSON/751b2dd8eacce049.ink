VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelativesSc = "Sibling:StepSibling"
VAR NPC1OccupationSc = "HigherInPosition"

VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0HappinessCh = 0

My sister wants me to try to get her a job at my office but she isn’t really qualified.
What do I do?
* [Tell her I’m not going to]
    -> res1
* [Tell her she isn’t qualified but I know of another job she would be good for]
    -> res2
* [Give her resume to my boss]
    -> res3
* [Tell my boss she isn’t qualified but ask if %Pron:1:1% will interview her as a favor]
    -> res4

=== res1 === 
My sister gets annoyed with me. I feel badly and end up staying at work late to work overtime because I don’t feel like going home.
~TextForLog = "I guess I shouldn’t have been so blunt with my sister, but she isn’t qualified I didn’t want to give her resume to my boss! Anyway, I stayed late tonight and got on my boss’s good side. That’s not bad."
~Character0WealthCh = "%100%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My sister is thankful for my honesty and that I want to help her and she takes me out to dinner as a thank you.
~TextForLog = "My sister was happy with my honesty and I am definitely going to try to land her a different job. She took me out to dinner and we had a fantastic time!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
My sister is thankful but my boss is annoyed at me for wasting %Pron:1:3% time. I work overtime to try to make it up to my boss.
~TextForLog = "My sister is appreciative of me trying but my boss is annoyed I wasted %Pron:1:3% time. Here I go working overtime to try to get back on %Pron:1:3% good side!"
~Character0WealthCh = "%100%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
My boss doesn’t mind and does the interview but my sister finds out that I said she wasn’t qualified and gets angry with me.
~TextForLog = "It was really nice of my boss to do all of this for me, we definitely got closer. But I don’t know how my sister found out but she is so angry with me! Jeez, I was trying to spare her feelings!"
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
