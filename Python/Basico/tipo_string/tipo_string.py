
# Em python, um dado é considerável string sempre que:

# Estiver entre áspas simples -> 'umas string', '234', 'True'
# Estiver entre áspas duplas -> "umas string", "234", "True"
# Estiver entre áspas simples triplas -> '''umas string''', '''234''', '''True'''
# Estiver entre áspas duplas triplas -> """umas string""", """234""", """True"""


"""
  # quebra de linha:

  nome = 'Lucas \nSantos' -> \n quebra linha

  ou

  nome = '''Lucas 
  Santos''' 
  
  -> aspas triplas permite quebrar linha no texto
  

  # Para saber todos os métodos que podemos ser utilizados em um tipo de dado:
  dir(nome_da_variavel)

  nome = 'Lucas'
  print(dir(nome))
  
  [
    '__add__', '__class__', '__contains__', '__delattr__', '__dir__', '__doc__', '__eq__', 
    '__format__', '__ge__', '__getattribute__', '__getitem__', '__getnewargs__', '__getstate__', 
    '__gt__', '__hash__', '__init__', '__init_subclass__', '__iter__', '__le__', '__len__', 
    '__lt__', '__mod__', '__mul__', '__ne__', '__new__', '__reduce__', '__reduce_ex__', '__repr__',
    '__rmod__', '__rmul__', '__setattr__', '__sizeof__', '__str__', '__subclasshook__', 
    'capitalize', 'casefold', 'center', 'count', 'encode', 'endswith', 'expandtabs', 'find', 
    'format', 'format_map', 'index', 'isalnum', 'isalpha', 'isascii', 'isdecimal', 'isdigit', 
    'isidentifier', 'islower', 'isnumeric', 'isprintable', 'isspace', 'istitle', 'isupper', 
    'join', 'ljust', 'lower', 'lstrip', 'maketrans', 'partition', 'removeprefix', 'removesuffix', 
    'replace', 'rfind', 'rindex', 'rjust', 'rpartition', 'rsplit', 'rstrip', 'split', 'splitlines',
    'startswith', 'strip', 'swapcase', 'title', 'translate', 'upper', 'zfill'
  ]
  
  print(nome.upper()) -> transforma todas as letras em maiúsculas
  print(nome.lower()) -> transforma todas as letras em minúsculas
    
  print(nome.split()) -> transforma em uma lista de strings
  print(nome[5:15]) -> slice de string -> corta e exibe apenas oq tem no intervalo
  
  nome = "Lucas Santos"
     posições = [ 0,   1,   2,   3,   4,   5,   6,   7,   8,   9,  10,  11]
  stringArray = ['L', 'u', 'c', 'a', 's', ' ', 'S', 'a', 'n', 't', 'o', 's']
  print(nome[0:6]) -> Lucas -> tem que passar o elemento que deseja mais 1, o 6 não é exibido em nome[0:6]

  [::-1] -> comece do primeiro elemento, vá até o ultimo elemento e inverta
  print(nome[::-1])
  
"""
