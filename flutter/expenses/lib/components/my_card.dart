import 'package:flutter/material.dart';

class MyCard extends StatelessWidget {
  final Color? color;
  final double? borderRadius;
  final double? elevation;
  final String title;

  const MyCard({
    super.key,
    required this.title,
    this.color,
    this.borderRadius = 4,
    this.elevation = 5,
  });

  @override
  Widget build(BuildContext context) {
    return Card(
      color: color,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(borderRadius!),
      ),
      elevation: elevation,
      child: Text(title),
    );
  }
}
