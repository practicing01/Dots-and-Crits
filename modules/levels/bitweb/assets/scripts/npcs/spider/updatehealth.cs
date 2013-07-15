function class_bitspider::updatehealth(%this)
{

Audiere_Reset(%this.parentbitweb.sound_bitspiderdeath);
Audiere_Play(%this.parentbitweb.sound_bitspiderdeath,0,1.0);

%this.parentbitweb.score++;
gui_text_player2score.setText("Score: "@%this.parentbitweb.score);

%this.parentbitweb.simset_spiders.remove(%this);
%this.safeDelete();

}
