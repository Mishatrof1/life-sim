VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Соседи строят дом,  а под их новым крыльцом попала в ловушку семья енотов. Соседи не желают разрушать крыльцо, чтобы вызволить зверьков. Что делать?
* [Ночью тайно разворотить крыльцо и спасти енотов]
    -> res1
* [Позвонить спасателям]
    -> res2
* [Я не стану портить отношения с хорошими людьми ради енотов]
    -> res3
* [Предложить соседям оплатить работу по восстановлению крыльца после спасения енотов]
    -> res4

=== res1 === 
Я спасла зверьков, но напрочь разругалась с соседями. Они угрожали мне полицией, а я им зоозащитниками
~TextForLog = "Под соседским крыльцом попала в ловушку семья енотов. Соседи не желают разрушать крыльцо, чтобы вызволить зверьков. Это сделала я. С соседями мы поругались, но зверьки спасены."
* [Ok]
-> END
=== res2 === 
Соседи не пустили спасателей, заявив, что это частная территория и там некого спасать
~TextForLog = "Под соседским крыльцом попала в ловушку семья енотов. Соседи не желают разрушать крыльцо, чтобы вызволить зверьков. Я позвонила спасателям, но соседи их не пустили на свою территорию."
* [Ok]
-> END
=== res3 === 
Енотов, конечно, жаль. Но это обычные вредители
~TextForLog = "Под соседским крыльцом попала в ловушку семья енотов. Соседи не желают разрушать крыльцо, чтобы вызволить зверьков. Я не стала портить отношения с соседями, хотя енотов жаль."
* [Ok]
-> END
=== res4 === 
Соседи согласились. Хоть мне это и влетело в копеечку, но семья енотов была спасена
~TextForLog = "Под соседским крыльцом попала в ловушку семья енотов. Соседи не желают разрушать крыльцо, чтобы вызволить зверьков. Я дала соседям денег и они позволили мне спасти зверьков."
* [Ok]
-> END