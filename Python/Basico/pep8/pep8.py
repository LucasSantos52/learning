"""
PEP - Python Enhancement Proposal

são propostas de melhorias para a linguagem Python

The Zen of Python
import this
"""


"""
    A ideia de PEP8 é que possamos escrever  codigo Python de forma Pythônica.
    
    [1] - Utilize Camel Case para nomes de classes:
"""


class Calculadora:
    pass


class CalculadoraCientifica:
    pass


"""
    [2] - Utilize nome em minúsculo, separados por underline para funções ou variáveis    
"""


def soma():
    pass


def soma_dois():
    pass


numero = 4
numro_impar = 5


"""
    [3] - Utilize 4 espaços para identação! (NÃO use tab)
"""

if 'a' in 'banana':
    print("tem")


"""
    [4] - 2 Linhas em branco antes da classe
    - Separar funções e definições de classe com duas linhas em branco
    - Métodos dentro de uma classe dever ser separados com uma única linha em branco
"""


class linhasEmBranco:
    pass


class outraClasse:
    def method():
        pass

    def anotherMethod():
        pass


"""
    [5] - Imports devem ser sempre feitos em linhas separadas
"""
# import errado
# import sys, os

# -> import correto
# import sys
# import os

# não há problemas em importar até 3 classes/objetos de uma biblioteca em uma unica linha
# from types import StringType, ListType

# caso tenha muitos imports de um mesmo pacote, recomenda-se fazer:
# from types import {
#    StringTypes,
#    ListTypes,
#    SetTypes,
#    OutroTypes,
# }

# imports devem ser colocados no topo do arquivo,logo depois de quaisquer comentarios
# ou docstrings e antes de constantes ou variáveis globais


"""
    [6] - Espaços em expressões e instruções
"""
# não faça isso:
# funcao( algo[ 1 ], { outro: 2 } )

# -> faça
# funcao(algo[1], {outro:2})

# não faça:
# algo (1)

# -> faça
# algo(1)

# não faça
# dict ['chave'] = lista [indice]

# -> faça
# dict['chave'] = lista[indice]

# não faça
# x              = 1
# y              = 3
# variavel_longa = 5

# -> faça
# x = 1
# y = 3
# variavel_longa = 5


"""
    [7] - termine sempre uma instrução com uma nova linha
"""
print("Hello world")
