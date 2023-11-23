"""
    Escopo de variáveis
    
    Dois escopos:
    
    1 - Variáveis Globais:
        - são reconhecidas em todo o programa
    
    2 - Variáveis locais:
        - são reconhecidas apenas no bloco onde foram declaradas, ou seja,
        seu wscopo está limitado ao bloco onde foi declarada.
        
    apara declarar variaveis em Python fazemos:
    
    nome_da_variavel = valor_da_variavel
    
    Python é uma linguagem de tipagem dinâmica. Isso significa que ao
    declararmos uma variável, nós não colocamos o tipo de dado dela.
    Este tipo é inferido ao atribuírmos o valor da mesma, ou seja, 
    por inferência.
    
    
    
    numero = 42 -> tipo interiro
    o tipo muda dinâmicamente, quando redefinimos o tipo de dado, ex.:
    numero = "Lucas" -> tipo string
    
    
    
    
    # exemplo de variável global, em qualquer lugar do codigo
    pode ser encontrada:
    
    numero = 23 
    
    
    
    # exemplo de variável dinâmica    
    
    if numero > 25:
        novo = numero + 10 
        
    -> a variável novo está declarada dentro do bloco do if, portanto
        só existe localmente dentro do if    
    
    
"""