"""
  Algebra Booleana, criada por George Boole, 2 constantes, verdadeiro ou falso

  # obs: sempre com inicial maiúscula:
  errado:
  true, false

  certo:
  True, False


### Opeações basicas

# Negação (not)
-> fazendo a negação, se o valor booleano for verdadeiro o resultado sera falso,
se for falso o resultado sera verdadeiro, ou seja, sempre o contrario

ativo = False
print(not ativo) = True

ativo = True
print(not ativo) = False


# Ou (or)
-> é uma operação binaria, ou seja depende de dois valores. ou um ou outro deve ser verdadeiro

True or True = True
True or False = True
False or True = True
False or False = False


# E (and)
-> também é uma operação binária, ou seja, depende de dois valores, ambos os valores devem ser verdadeiros

True or True = True
True or False = False
False or True = False
False or False = False

"""