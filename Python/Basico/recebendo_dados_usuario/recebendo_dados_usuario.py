"""
  Recebendo dados do usuário

  input() -> todo dado recebido no input é tipo string

  Em Python, string é tudo que estiver entre:
  - Aspas simples -> 'Lucas'
  - Aspas duplas -> "Lucas"
  - Aspas simples triplas -> '''Lucas'''
  e
"""
  # - Aspas duplas triplas -> """Lucas""" 
  

#entrada de dados
# print("Qual o seu nome?")
# nome = input() #input -> entrada
nome = input("Qual seu nome? ")

# print("Seja bem vindo(a) %s" % nome) #exemplo de print antigo, versão do python 2x
# print("Seja bem vindo(a) {0}".format(nome)) #print python moderno, 3.x
print(f"Seja bem vindo(a) {nome}") #modo mais atual python 3.7

# print("Qual a sua idade?")
# idade = input()
# idade = input("Qual sua idade? ")
idade = int(input("Qual sua idade? "))

#processamento

#saida de dados

# print("%s tem %s anos" % (nome, idade)) #exemplo de print antigo, versão do python 2x
# print("{0} tem {1} anos.".format(nome, idade)) #print mais moderno, 3.x
print(f"{nome} tem {idade} anos.") #modo mais atual python 3.7

"""
  int(idade) => cast

  Cast é a conversão de um tipo de dado para outro
"""
ano_atual = 2023
# print(f"{nome} nasceu em {ano_atual - int(idade)}.")
print(f"{nome} nasceu em {ano_atual - idade}.") #fazendo cast direto na var idade


"""
  O input faz parte de uma lista de recursos integrados da linguagem, 
  dentro de:

  no console python:

  dir()
  -> ['__annotations__', '__builtins__', '__doc__', '__loader__', '__name__', '__package__', '__spec__']

  dir(__builtins__)
  -> ['ArithmeticError', 'AssertionError', 'AttributeError', 'BaseException', 
  'BaseExceptionGroup', 'BlockingIOError', 'BrokenPipeError', 'BufferError', 'BytesWarning', 
  'ChildProcessError', 'ConnectionAbortedError', 'ConnectionError', 'ConnectionRefusedError', 
  'ConnectionResetError', 'DeprecationWarning', 'EOFError', 'Ellipsis', 'EncodingWarning', 
  'EnvironmentError', 'Exception', 'ExceptionGroup', 'False', 'FileExistsError', 
  'FileNotFoundError', 'FloatingPointError', 'FutureWarning', 'GeneratorExit', 'IOError', 
  'ImportError', 'ImportWarning', 'IndentationError', 'IndexError', 'InterruptedError', 
  'IsADirectoryError', 'KeyError', 'KeyboardInterrupt', 'LookupError', 'MemoryError', 
  'ModuleNotFoundError', 'NameError', 'None', 'NotADirectoryError', 'NotImplemented', 
  'NotImplementedError', 'OSError', 'OverflowError', 'PendingDeprecationWarning', 
  'PermissionError', 'ProcessLookupError', 'RecursionError', 'ReferenceError', 'ResourceWarning', 
  'RuntimeError', 'RuntimeWarning', 'StopAsyncIteration', 'StopIteration', 'SyntaxError', 
  'SyntaxWarning', 'SystemError', 'SystemExit', 'TabError', 'TimeoutError', 'True', 'TypeError', 
  'UnboundLocalError', 'UnicodeDecodeError', 'UnicodeEncodeError', 'UnicodeError', 
  'UnicodeTranslateError', 'UnicodeWarning', 'UserWarning', 'ValueError', 'Warning', 
  'WindowsError', 'ZeroDivisionError', '_', '__build_class__', '__debug__', '__doc__', 
  '__import__', '__loader__', '__name__', '__package__', '__spec__', 'abs', 'aiter', 'all', 
  'anext', 'any', 'ascii', 'bin', 'bool', 'breakpoint', 'bytearray', 'bytes', 'callable', 'chr', 
  'classmethod', 'compile', 'complex', 'copyright', 'credits', 'delattr', 'dict', 'dir',   
  'divmod', 'enumerate', 'eval', 'exec', 'exit', 'filter', 'float', 'format', 'frozenset',   
  'getattr', 'globals', 'hasattr', 'hash', 'help', 'hex', 'id', 'input', 'int', 'isinstance',
   'issubclass', 'iter', 'len', 'license', 'list', 'locals', 'map', 'max', 'memoryview', 'min', 
   'next', 'object', 'oct', 'open', 'ord', 'pow', 'print', 'property', 'quit', 'range', 'repr', 
   'reversed', 'round', 'set', 'setattr', 'slice', 'sorted', 'staticmethod', 'str', 'sum', 
   'super', 'tuple', 'type', 'vars', 'zip']
"""

