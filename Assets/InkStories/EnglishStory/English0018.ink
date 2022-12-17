VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Female"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



The homework our teacher gave us is really hard. How do I handle it?
* [Spend a lot of hours on this homework, but solve it]
    -> res1
* [Flirt with the class nerd to cheat off him]
    -> res2
* [Don't do this homework and try my luck]
    -> res3
* [Pretend to be sick to wave this task]
    -> res4

=== res1 === 
Our teacher was ill that day and didn't check it anyways. It was a complete waste of time!
~TextForLog = "Our teacher gave us a really hard homework. I did it all, but the teacher was sick that day and didn't check it anyways. It was a total waste of time."
* [Ok]
-> END
=== res2 === 
Our teacher was ill that day and didn't check it anyways. That dork keeps trailing me, how do I lose him?
~TextForLog = "Our teacher gave us a really hard homework. I flirted with the class nerd and he did the task for me.But the teacher was sick that day and didn't check it anyways. I wonder how I can lose the dork now."
* [Ok]
-> END
=== res3 === 
Bingo! I was so lucky our teacher was sick that day and didn't check it anyways
~TextForLog = "Our teacher gave us a really hard homework. I decided to try my luck and not to do it. And I was lucky cuz the teacher got sick and didn't check it."
* [Ok]
-> END
=== res4 === 
I tried for nothing, as, unlike me, the teacher really got sick and didn't check it anyways
~TextForLog = "Our teacher gave us a really hard homework. I pretended to be ill in order not to do the task. But I tried for nothing cuz the teacher got sick and didn't check it anyways."
* [Ok]
-> END