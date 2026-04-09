import 'package:app_teste/components/index.dart';
import 'package:flutter/material.dart';

class Questionario extends StatelessWidget {
  final List<Map<String, dynamic>> perguntas;
  final int perguntaSelecinada;
  final void Function(int) quandoResponder;

  Questionario({
    required this.perguntaSelecinada,
    required this.perguntas,
    required this.quandoResponder,
  });

  bool get temPerguntaSelecionada {
    return perguntaSelecinada < perguntas.length;
  }

  @override
  Widget build(BuildContext context) {
    List<Map<String, dynamic>> respostas = temPerguntaSelecionada
        ? perguntas[perguntaSelecinada]['respostas']
        : [];

    return Column(
      children: <Widget>[
        QuestionTitle(perguntas[perguntaSelecinada]['texto']),
        ...respostas.map((resp) {
          return Resposta(
            resp['texto'],
            () => quandoResponder(resp['pontuacao']),
          );
        }),
      ],
    );
  }
}
