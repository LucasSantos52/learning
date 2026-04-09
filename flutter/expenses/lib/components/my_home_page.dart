import 'package:expenses/components/_.dart';
import 'package:flutter/material.dart';

class MyHomePage extends StatelessWidget {
  const MyHomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Despesas Pessoais')),
      body: Column(
        children: <Widget>[
          SizedBox(
            width: double.infinity,
            child: MyCard(title: "Gráfico"),
          ),
          MyCard(title: "Lista de transações"),
        ],
      ),
    );
  }
}
