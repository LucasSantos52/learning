import 'package:app_teste/components/index.dart';
import 'package:flutter/material.dart';

class FinalResult extends StatelessWidget {
  final int pontuacao;
  final void Function() reiniciarQuestionario;

  FinalResult(this.pontuacao, this.reiniciarQuestionario);

  String get frasePontuacao {
    if (pontuacao < 8) {
      return 'Parabéns! $pontuacao pontos.';
    } else if (pontuacao < 12) {
      return 'Você é bom! $pontuacao pontos.';
    } else if (pontuacao < 16) {
      return 'Impressionante! $pontuacao pontos.';
    } else {
      return 'Nível Jedi! $pontuacao pontos.';
    }
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: <Widget>[
        Center(child: Text(frasePontuacao, style: TextStyle(fontSize: 28))),
        Resposta('Reiniciar?', reiniciarQuestionario),
      ],
    );
  }
}
