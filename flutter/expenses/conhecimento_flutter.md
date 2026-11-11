# Flutter - Guia Prático para Desenvolvedores

> Guia direto ao ponto para quem já programa e quer produtividade em Flutter

## 📋 Índice
- [Comandos Essenciais](#comandos-essenciais)
- [Fundamentos](#fundamentos)
- [Widgets](#widgets)
- [Gestão de Estado](#gestão-de-estado)
- [Navegação](#navegação)
- [HTTP e APIs](#http-e-apis)
- [Layouts](#layouts)
- [Listas e Performance](#listas-e-performance)
- [Formulários](#formulários)
- [Animações](#animações)
- [Temas e Estilo](#temas-e-estilo)
- [Boas Práticas](#boas-práticas)
- [Packages Essenciais](#packages-essenciais)

---

## Comandos Essenciais

```bash
# Criar projeto
flutter create nome_app
flutter create --org com.empresa nome_app  # Com package name customizado

# Executar
flutter run                    # Roda no device conectado
flutter run -d chrome         # Roda no Chrome
flutter run -d windows        # Roda no Windows
flutter run --release         # Build otimizado

# Build
flutter build apk             # Android APK
flutter build appbundle       # Android Bundle (para Play Store)
flutter build ios             # iOS (precisa de Mac)
flutter build web             # Web
flutter build windows         # Desktop Windows

# Desenvolvimento
flutter pub get               # Instala dependências (npm install)
flutter pub upgrade           # Atualiza packages
flutter pub outdated          # Mostra packages desatualizados
flutter clean                 # Limpa cache de build (resolve 90% dos problemas)

# Análise e Testes
flutter analyze               # Linter
flutter test                  # Roda testes
flutter doctor                # Verifica setup do ambiente

# Hot Reload
# Durante execução:
# r - Hot reload (mantém estado)
# R - Hot restart (reinicia app)
# q - Quit
```

---

## Fundamentos

### Arquitetura Flutter

```
Tudo é Widget
    ↓
Widget Tree (como Virtual DOM)
    ↓
Element Tree
    ↓
RenderObject Tree
    ↓
Pixels na tela
```

**Importante**: Flutter não usa componentes nativos, ele desenha TUDO do zero. É tipo um canvas game engine aplicado a UI.

### Diferenças do Web

| Web (React/Vue) | Flutter |
|----------------|---------|
| HTML/CSS/JS | Dart puro |
| DOM | Widget Tree |
| `<div>` | `Container` |
| `<span>` | `Text` |
| CSS Flexbox | `Column`/`Row` |
| CSS Grid | `GridView` |
| `useState` | `setState` |
| Context API | `InheritedWidget` |
| npm/yarn | pub |
| Hot reload | Hot reload (melhor!) |

---

## Widgets

### Stateless vs Stateful

```dart
// Stateless - UI pura, sem estado interno
// Use quando: dados vêm de props, componente não muda
class MeuBotao extends StatelessWidget {
  final String texto;
  final VoidCallback onPressed;
  
  const MeuBotao({
    super.key,
    required this.texto,
    required this.onPressed,
  });

  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      onPressed: onPressed,
      child: Text(texto),
    );
  }
}

// Stateful - Tem estado interno que pode mudar
// Use quando: contador, formulário, animação, qualquer coisa que muda
class Contador extends StatefulWidget {
  const Contador({super.key});

  @override
  State<Contador> createState() => _ContadorState();
}

class _ContadorState extends State<Contador> {
  int _count = 0;

  void _incrementar() {
    setState(() {  // Equivalente ao setCount no React
      _count++;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text('$_count'),
        ElevatedButton(
          onPressed: _incrementar,
          child: const Text('Incrementar'),
        ),
      ],
    );
  }
}
```

### Lifecycle de Stateful Widget

```dart
class WidgetComLifecycle extends StatefulWidget {
  @override
  State<WidgetComLifecycle> createState() => _WidgetComLifecycleState();
}

class _WidgetComLifecycleState extends State<WidgetComLifecycle> {
  @override
  void initState() {
    super.initState();
    // Equivalente ao componentDidMount ou useEffect(() => {}, [])
    // Roda UMA vez quando o widget é criado
    // Use para: inicializar dados, subscrições, listeners
    print('Widget criado');
  }

  @override
  void didUpdateWidget(WidgetComLifecycle oldWidget) {
    super.didUpdateWidget(oldWidget);
    // Equivalente ao componentDidUpdate
    // Roda quando as props mudam
  }

  @override
  void dispose() {
    super.dispose();
    // Equivalente ao componentWillUnmount ou return do useEffect
    // Use para: limpar timers, cancelar subscrições, dispose controllers
    print('Widget destruído');
  }

  @override
  Widget build(BuildContext context) {
    // Re-renderiza quando setState é chamado
    return Container();
  }
}
```

### Construindo Widgets Reutilizáveis

```dart
// BOA PRÁTICA: Widget reutilizável e configurável
class CustomCard extends StatelessWidget {
  final String title;
  final String? subtitle;
  final Widget? leading;
  final Widget? trailing;
  final VoidCallback? onTap;
  final EdgeInsets? padding;
  final Color? backgroundColor;

  const CustomCard({
    super.key,
    required this.title,
    this.subtitle,
    this.leading,
    this.trailing,
    this.onTap,
    this.padding,
    this.backgroundColor,
  });

  @override
  Widget build(BuildContext context) {
    return Card(
      color: backgroundColor,
      child: InkWell(  // Adiciona efeito ripple no tap
        onTap: onTap,
        child: Padding(
          padding: padding ?? const EdgeInsets.all(16),
          child: Row(
            children: [
              if (leading != null) ...[
                leading!,
                const SizedBox(width: 12),
              ],
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      title,
                      style: const TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    if (subtitle != null)
                      Text(
                        subtitle!,
                        style: const TextStyle(
                          fontSize: 14,
                          color: Colors.grey,
                        ),
                      ),
                  ],
                ),
              ),
              if (trailing != null) trailing!,
            ],
          ),
        ),
      ),
    );
  }
}

// Uso:
CustomCard(
  title: 'Título',
  subtitle: 'Subtítulo opcional',
  leading: const Icon(Icons.person),
  trailing: const Icon(Icons.arrow_forward),
  onTap: () => print('Clicou'),
)
```

### Widgets Base Essenciais

```dart
// Container - equivalente a <div>
Container(
  width: 100,
  height: 100,
  padding: const EdgeInsets.all(8),
  margin: const EdgeInsets.all(16),
  decoration: BoxDecoration(
    color: Colors.blue,
    borderRadius: BorderRadius.circular(8),
    boxShadow: [
      BoxShadow(
        color: Colors.black26,
        blurRadius: 4,
        offset: Offset(0, 2),
      ),
    ],
  ),
  child: Text('Conteúdo'),
)

// SizedBox - espaçamento ou tamanho fixo
SizedBox(height: 16)  // Espaço vertical
SizedBox(width: 16)   // Espaço horizontal
SizedBox(
  width: 100,
  height: 100,
  child: child,
)

// Padding - só padding, mais leve que Container
Padding(
  padding: const EdgeInsets.all(16),
  child: child,
)

// Center - centraliza filho
Center(child: Text('Centralizado'))

// Expanded - ocupa espaço disponível (como flex: 1)
Row(
  children: [
    Container(width: 50),
    Expanded(child: Text('Ocupa resto')),
  ],
)

// Flexible - mais flexível que Expanded
Flexible(
  flex: 2,  // Proporção
  fit: FlexFit.tight,  // ou loose
  child: child,
)

// Wrap - quebra linha automática (como flex-wrap)
Wrap(
  spacing: 8,
  runSpacing: 8,
  children: [
    Chip(label: Text('Tag 1')),
    Chip(label: Text('Tag 2')),
    Chip(label: Text('Tag 3')),
  ],
)
```

---

## Gestão de Estado

### 1. setState (Estado Local)

```dart
// Use para: estado simples e local
class _MyWidgetState extends State<MyWidget> {
  bool _isLoading = false;

  Future<void> _loadData() async {
    setState(() => _isLoading = true);
    await Future.delayed(Duration(seconds: 2));
    setState(() => _isLoading = false);
  }
}
```

### 2. InheritedWidget (Context API do Flutter)

```dart
// Compartilha dados na árvore sem prop drilling
class UserData extends InheritedWidget {
  final String username;
  final String email;

  const UserData({
    super.key,
    required this.username,
    required this.email,
    required super.child,
  });

  static UserData? of(BuildContext context) {
    return context.dependOnInheritedWidgetOfExactType<UserData>();
  }

  @override
  bool updateShouldNotify(UserData oldWidget) {
    return username != oldWidget.username || email != oldWidget.email;
  }
}

// Uso:
final user = UserData.of(context);
print(user?.username);
```

### 3. Provider (Recomendado para apps médios)

```dart
// pubspec.yaml
// dependencies:
//   provider: ^6.0.0

// Model com ChangeNotifier
class CartModel extends ChangeNotifier {
  final List<Item> _items = [];

  List<Item> get items => _items;
  
  int get totalItems => _items.length;
  
  double get totalPrice => _items.fold(0, (sum, item) => sum + item.price);

  void addItem(Item item) {
    _items.add(item);
    notifyListeners();  // Notifica widgets que estão ouvindo
  }

  void removeItem(String id) {
    _items.removeWhere((item) => item.id == id);
    notifyListeners();
  }
}

// Setup no main.dart
void main() {
  runApp(
    ChangeNotifierProvider(
      create: (context) => CartModel(),
      child: MyApp(),
    ),
  );
}

// Uso nos widgets
class CartScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    // Ouve mudanças e reconstrói widget
    final cart = Provider.of<CartModel>(context);
    
    // Ou com Consumer para rebuild seletivo
    return Consumer<CartModel>(
      builder: (context, cart, child) {
        return Text('${cart.totalItems} itens');
      },
    );
    
    // Ou para só ler sem ouvir mudanças
    final cart = Provider.of<CartModel>(context, listen: false);
    cart.addItem(item);
  }
}
```

### 4. Riverpod (Moderno, mais seguro que Provider)

```dart
// Provider global
final counterProvider = StateProvider<int>((ref) => 0);

// Uso
class CounterWidget extends ConsumerWidget {
  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final count = ref.watch(counterProvider);
    
    return Column(
      children: [
        Text('$count'),
        ElevatedButton(
          onPressed: () => ref.read(counterProvider.notifier).state++,
          child: Text('Incrementar'),
        ),
      ],
    );
  }
}
```

### 5. GetX (All-in-one: estado, rotas, dependências)

```dart
class CounterController extends GetxController {
  var count = 0.obs;  // Observable
  
  void increment() => count++;
}

// Uso
class Home extends StatelessWidget {
  final CounterController c = Get.put(CounterController());

  @override
  Widget build(BuildContext context) {
    return Obx(() => Text('${c.count}'));
  }
}
```

**Recomendação**: Provider para maioria dos casos, Riverpod se quiser algo mais robusto.

---

## Navegação

### Navegação Básica

```dart
// Push (ir para nova tela)
Navigator.push(
  context,
  MaterialPageRoute(builder: (context) => SegundaTela()),
);

// Pop (voltar)
Navigator.pop(context);

// Pop com retorno de dados
Navigator.pop(context, 'dados de retorno');

// Push e aguardar retorno
final resultado = await Navigator.push(
  context,
  MaterialPageRoute(builder: (context) => SegundaTela()),
);
print(resultado);

// Push replacement (substitui tela atual)
Navigator.pushReplacement(
  context,
  MaterialPageRoute(builder: (context) => NovaTela()),
);

// Push e remove todas anteriores (ex: após login)
Navigator.pushAndRemoveUntil(
  context,
  MaterialPageRoute(builder: (context) => Home()),
  (route) => false,  // Remove todas
);
```

### Rotas Nomeadas

```dart
// main.dart
MaterialApp(
  initialRoute: '/',
  routes: {
    '/': (context) => HomeScreen(),
    '/details': (context) => DetailsScreen(),
    '/settings': (context) => SettingsScreen(),
  },
);

// Navegação
Navigator.pushNamed(context, '/details');
Navigator.pushNamed(
  context,
  '/details',
  arguments: {'id': '123'},  // Passar dados
);

// Receber argumentos
class DetailsScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final args = ModalRoute.of(context)!.settings.arguments as Map;
    return Text('ID: ${args['id']}');
  }
}
```

### Transições Customizadas

```dart
Navigator.push(
  context,
  PageRouteBuilder(
    pageBuilder: (context, animation, secondaryAnimation) => SegundaTela(),
    transitionsBuilder: (context, animation, secondaryAnimation, child) {
      const begin = Offset(1.0, 0.0);  // Da direita
      const end = Offset.zero;
      final tween = Tween(begin: begin, end: end);
      final offsetAnimation = animation.drive(tween);
      
      return SlideTransition(
        position: offsetAnimation,
        child: child,
      );
    },
  ),
);
```

---

## HTTP e APIs

### Setup HTTP Client

```yaml
# pubspec.yaml
dependencies:
  http: ^1.1.0
```

```dart
import 'dart:convert';
import 'package:http/http.dart' as http;

// Model
class User {
  final String id;
  final String name;
  final String email;

  User({required this.id, required this.name, required this.email});

  factory User.fromJson(Map<String, dynamic> json) {
    return User(
      id: json['id'],
      name: json['name'],
      email: json['email'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'name': name,
      'email': email,
    };
  }
}

// Service
class ApiService {
  static const String baseUrl = 'https://api.exemplo.com';

  // GET
  Future<List<User>> getUsers() async {
    final response = await http.get(
      Uri.parse('$baseUrl/users'),
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode == 200) {
      final List<dynamic> data = json.decode(response.body);
      return data.map((json) => User.fromJson(json)).toList();
    } else {
      throw Exception('Erro ao carregar usuários: ${response.statusCode}');
    }
  }

  // POST
  Future<User> createUser(User user) async {
    final response = await http.post(
      Uri.parse('$baseUrl/users'),
      headers: {'Content-Type': 'application/json'},
      body: json.encode(user.toJson()),
    );

    if (response.statusCode == 201) {
      return User.fromJson(json.decode(response.body));
    } else {
      throw Exception('Erro ao criar usuário');
    }
  }

  // PUT
  Future<User> updateUser(String id, User user) async {
    final response = await http.put(
      Uri.parse('$baseUrl/users/$id'),
      headers: {'Content-Type': 'application/json'},
      body: json.encode(user.toJson()),
    );

    if (response.statusCode == 200) {
      return User.fromJson(json.decode(response.body));
    } else {
      throw Exception('Erro ao atualizar usuário');
    }
  }

  // DELETE
  Future<void> deleteUser(String id) async {
    final response = await http.delete(
      Uri.parse('$baseUrl/users/$id'),
    );

    if (response.statusCode != 204) {
      throw Exception('Erro ao deletar usuário');
    }
  }
}
```

### Uso com FutureBuilder

```dart
class UsersScreen extends StatelessWidget {
  final ApiService _api = ApiService();

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<User>>(
      future: _api.getUsers(),
      builder: (context, snapshot) {
        // Loading
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: CircularProgressIndicator());
        }
        
        // Erro
        if (snapshot.hasError) {
          return Center(child: Text('Erro: ${snapshot.error}'));
        }
        
        // Sem dados
        if (!snapshot.hasData || snapshot.data!.isEmpty) {
          return const Center(child: Text('Nenhum usuário encontrado'));
        }
        
        // Sucesso
        final users = snapshot.data!;
        return ListView.builder(
          itemCount: users.length,
          itemBuilder: (context, index) {
            final user = users[index];
            return ListTile(
              title: Text(user.name),
              subtitle: Text(user.email),
            );
          },
        );
      },
    );
  }
}
```

### Alternativa com Dio (Mais completo)

```dart
// Dio é tipo o Axios do Flutter
import 'package:dio/dio.dart';

class ApiClient {
  final Dio _dio = Dio(
    BaseOptions(
      baseUrl: 'https://api.exemplo.com',
      connectTimeout: const Duration(seconds: 5),
      receiveTimeout: const Duration(seconds: 3),
      headers: {'Content-Type': 'application/json'},
    ),
  );

  ApiClient() {
    // Interceptors (middleware)
    _dio.interceptors.add(
      InterceptorsWrapper(
        onRequest: (options, handler) {
          // Adiciona token em todas requisições
          options.headers['Authorization'] = 'Bearer $token';
          return handler.next(options);
        },
        onError: (error, handler) {
          // Tratamento global de erros
          print('Erro: ${error.message}');
          return handler.next(error);
        },
      ),
    );
  }

  Future<List<User>> getUsers() async {
    final response = await _dio.get('/users');
    return (response.data as List).map((e) => User.fromJson(e)).toList();
  }
}
```

---

## Layouts

### Column e Row (Flexbox)

```dart
// Column - empilha verticalmente
Column(
  mainAxisAlignment: MainAxisAlignment.start,     // Alinhamento principal (vertical)
  crossAxisAlignment: CrossAxisAlignment.center,  // Alinhamento cruzado (horizontal)
  mainAxisSize: MainAxisSize.min,                 // min ou max
  children: [
    Text('Item 1'),
    Text('Item 2'),
    Text('Item 3'),
  ],
)

// Row - empilha horizontalmente
Row(
  mainAxisAlignment: MainAxisAlignment.spaceBetween,
  crossAxisAlignment: CrossAxisAlignment.center,
  children: [
    Icon(Icons.home),
    Text('Home'),
    Icon(Icons.arrow_forward),
  ],
)

// Espaçamento entre itens
Column(
  children: [
    Text('Item 1'),
    SizedBox(height: 8),
    Text('Item 2'),
    Spacer(),  // Ocupa todo espaço disponível
    Text('Item 3'),
  ],
)
```

### Stack (position: absolute)

```dart
Stack(
  children: [
    // Background
    Container(color: Colors.blue, width: 200, height: 200),
    
    // Positioned - controle fino de posição
    Positioned(
      top: 10,
      left: 10,
      child: Icon(Icons.star),
    ),
    
    // Positioned.fill - ocupa tudo
    Positioned.fill(
      child: Container(color: Colors.black26),
    ),
    
    // Align - alinhamento relativo
    Align(
      alignment: Alignment.bottomRight,
      child: Padding(
        padding: EdgeInsets.all(8),
        child: Icon(Icons.favorite),
      ),
    ),
  ],
)
```

### ListView (Listas)

```dart
// ListView.builder - para listas dinâmicas (melhor performance)
ListView.builder(
  itemCount: items.length,
  itemBuilder: (context, index) {
    return ListTile(
      title: Text(items[index]),
    );
  },
)

// ListView.separated - com separadores
ListView.separated(
  itemCount: items.length,
  itemBuilder: (context, index) => ListTile(title: Text(items[index])),
  separatorBuilder: (context, index) => Divider(),
)

// ListView customizado
ListView.custom(
  childrenDelegate: SliverChildBuilderDelegate(
    (context, index) => ItemWidget(items[index]),
    childCount: items.length,
  ),
)

// Scroll horizontal
ListView.builder(
  scrollDirection: Axis.horizontal,
  itemCount: items.length,
  itemBuilder: (context, index) => Container(width: 100, child: ...),
)
```

### GridView

```dart
// Grid com colunas fixas
GridView.count(
  crossAxisCount: 3,  // 3 colunas
  crossAxisSpacing: 10,
  mainAxisSpacing: 10,
  children: items.map((item) => ItemCard(item)).toList(),
)

// Grid com largura fixa de item
GridView.extent(
  maxCrossAxisExtent: 150,  // Max 150px por item
  children: [...],
)

// Grid builder (melhor para listas grandes)
GridView.builder(
  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
    crossAxisCount: 2,
    childAspectRatio: 1.5,  // Proporção largura/altura
  ),
  itemCount: items.length,
  itemBuilder: (context, index) => ItemCard(items[index]),
)
```

---

## Listas e Performance

### Keys (quando usar)

```dart
// Use keys quando a ordem dos itens pode mudar
ListView.builder(
  itemCount: items.length,
  itemBuilder: (context, index) {
    return ItemWidget(
      key: ValueKey(items[index].id),  // Key baseada em ID único
      item: items[index],
    );
  },
)

// Tipos de keys:
ValueKey('meu-id')           // Para valores primitivos
ObjectKey(meuObjeto)         // Para objetos
UniqueKey()                  // Sempre única (use com cuidado)
GlobalKey()                  // Acessa estado de outro widget
```

### ListView vs SingleChildScrollView

```dart
// ListView - virtualizado, melhor para listas grandes
ListView.builder(...)  // ✅ Cria só widgets visíveis

// SingleChildScrollView - NÃO virtualizado
SingleChildScrollView(
  child: Column(
    children: List.generate(1000, (i) => Text('$i')),  // ❌ Cria 1000 widgets
  ),
)

// Use SingleChildScrollView para:
// - Conteúdo pequeno e fixo
// - Layouts complexos que não são listas
```

### Lazy Loading (Paginação)

```dart
class InfiniteListScreen extends StatefulWidget {
  @override
  _InfiniteListScreenState createState() => _InfiniteListScreenState();
}

class _InfiniteListScreenState extends State<InfiniteListScreen> {
  final ScrollController _scrollController = ScrollController();
  List<Item> _items = [];
  int _page = 1;
  bool _isLoading = false;

  @override
  void initState() {
    super.initState();
    _loadItems();
    
    // Detecta quando chega no final da lista
    _scrollController.addListener(() {
      if (_scrollController.position.pixels ==
          _scrollController.position.maxScrollExtent) {
        _loadItems();
      }
    });
  }

  Future<void> _loadItems() async {
    if (_isLoading) return;
    
    setState(() => _isLoading = true);
    
    final newItems = await api.getItems(page: _page);
    
    setState(() {
      _items.addAll(newItems);
      _page++;
      _isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      controller: _scrollController,
      itemCount: _items.length + (_isLoading ? 1 : 0),
      itemBuilder: (context, index) {
        if (index == _items.length) {
          return Center(child: CircularProgressIndicator());
        }
        return ItemWidget(_items[index]);
      },
    );
  }

  @override
  void dispose() {
    _scrollController.dispose();
    super.dispose();
  }
}
```

---

## Formulários

### TextFormField e Validação

```dart
class FormScreen extends StatefulWidget {
  @override
  _FormScreenState createState() => _FormScreenState();
}

class _FormScreenState extends State<FormScreen> {
  final _formKey = GlobalKey<FormState>();
  final _emailController = TextEditingController();
  final _senhaController = TextEditingController();
  bool _obscurePassword = true;

  @override
  void dispose() {
    _emailController.dispose();
    _senhaController.dispose();
    super.dispose();
  }

  String? _validarEmail(String? value) {
    if (value == null || value.isEmpty) {
      return 'Email é obrigatório';
    }
    final emailRegex = RegExp(r'^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$');
    if (!emailRegex.hasMatch(value)) {
      return 'Email inválido';
    }
    return null;
  }

  String? _validarSenha(String? value) {
    if (value == null || value.isEmpty) {
      return 'Senha é obrigatória';
    }
    if (value.length < 6) {
      return 'Senha deve ter no mínimo 6 caracteres';
    }
    return null;
  }

  void _submit() {
    if (_formKey.currentState!.validate()) {
      // Formulário válido
      final email = _emailController.text;
      final senha = _senhaController.text;
      print('Email: $email, Senha: $senha');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Form(
      key: _formKey,
      child: Column(
        children: [
          TextFormField(
            controller: _emailController,
            decoration: InputDecoration(
              labelText: 'Email',
              hintText: 'seu@email.com',
              prefixIcon: Icon(Icons.email),
              border: OutlineInputBorder(),
            ),
            keyboardType: TextInputType.emailAddress,
            validator: _validarEmail,
          ),
          SizedBox(height: 16),
          TextFormField(
            controller: _senhaController,
            decoration: InputDecoration(
              labelText: 'Senha',
              prefixIcon: Icon(Icons.lock),
              suffixIcon: IconButton(
                icon: Icon(
                  _obscurePassword ? Icons.visibility : Icons.visibility_off,
                ),
                onPressed: () {
                  setState(() => _obscurePassword = !_obscurePassword);
                },
              ),
              border: OutlineInputBorder(),
            ),
            obscureText: _obscurePassword,
            validator: _validarSenha,
          ),
          SizedBox(height: 24),
          ElevatedButton(
            onPressed: _submit,
            child: Text('Entrar'),
          ),
        ],
      ),
    );
  }
}
```

### Outros Inputs

```dart
// Checkbox
Checkbox(
  value: _checked,
  onChanged: (value) => setState(() => _checked = value!),
)

// Switch
Switch(
  value: _enabled,
  onChanged: (value) => setState(() => _enabled = value),
)

// Radio
Radio<String>(
  value: 'opcao1',
  groupValue: _selectedOption,
  onChanged: (value) => setState(() => _selectedOption = value!),
)

// Slider
Slider(
  value: _currentValue,
  min: 0,
  max: 100,
  divisions: 10,
  label: _currentValue.round().toString(),
  onChanged: (value) => setState(() => _currentValue = value),
)

// DropdownButton
DropdownButton<String>(
  value: _selectedValue,
  items: ['Opção 1', 'Opção 2', 'Opção 3']
      .map((value) => DropdownMenuItem(
            value: value,
            child: Text(value),
          ))
      .toList(),
  onChanged: (value) => setState(() => _selectedValue = value),
)

// DatePicker
ElevatedButton(
  onPressed: () async {
    final date = await showDatePicker(
      context: context,
      initialDate: DateTime.now(),
      firstDate: DateTime(2000),
      lastDate: DateTime(2100),
    );
    if (date != null) {
      setState(() => _selectedDate = date);
    }
  },
  child: Text('Selecionar Data'),
)
```

---

## Animações

### Animações Implícitas (mais fáceis)

```dart
// AnimatedContainer - anima mudanças de propriedades
class AnimatedBox extends StatefulWidget {
  @override
  _AnimatedBoxState createState() => _AnimatedBoxState();
}

class _AnimatedBoxState extends State<AnimatedBox> {
  bool _expanded = false;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () => setState(() => _expanded = !_expanded),
      child: AnimatedContainer(
        duration: Duration(milliseconds: 300),
        curve: Curves.easeInOut,
        width: _expanded ? 200 : 100,
        height: _expanded ? 200 : 100,
        color: _expanded ? Colors.blue : Colors.red,
        child: Center(child: Text('Tap me')),
      ),
    );
  }
}

// Outros widgets animados implícitos:
AnimatedOpacity(opacity: _visible ? 1.0 : 0.0, duration: Duration(seconds: 1))
AnimatedAlign(alignment: _align, duration: Duration(seconds: 1))
AnimatedPadding(padding: _padding, duration: Duration(seconds: 1))
AnimatedPositioned(top: _top, left: _left, duration: Duration(seconds: 1))
AnimatedDefaultTextStyle(style: _style, duration: Duration(seconds: 1))
```

### Animações Explícitas (mais controle)

```dart
class ExplicitAnimationExample extends StatefulWidget {
  @override
  _ExplicitAnimationExampleState createState() =>
      _ExplicitAnimationExampleState();
}

class _ExplicitAnimationExampleState extends State<ExplicitAnimationExample>
    with SingleTickerProviderStateMixin {  // Necessário para AnimationController
  
  late AnimationController _controller;
  late Animation<double> _animation;

  @override
  void initState() {
    super.initState();
    
    _controller = AnimationController(
      duration: Duration(seconds: 2),
      vsync: this,
    );
    
    _animation = Tween<double>(begin: 0, end: 300).animate(
      CurvedAnimation(
        parent: _controller,
        curve: Curves.bounceOut,
      ),
    );
    
    _controller.forward();  // Inicia animação
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AnimatedBuilder(
      animation: _animation,
      builder: (context, child) {
        return Container(
          width: _animation.value,
          height: _animation.value,
          color: Colors.blue,
        );
      },
    );
  }
}
```

### Hero Animations (transição entre telas)

```dart
// Tela 1
Hero(
  tag: 'hero-image',  // Tag única
  child: Image.network('url'),
)

// Tela 2 (mesma tag)
Hero(
  tag: 'hero-image',
  child: Image.network('url'),
)
// Flutter anima automaticamente a transição!
```

### PageView com animações

```dart
PageView.builder(
  itemCount: pages.length,
  itemBuilder: (context, index) {
    return PageWidget(pages[index]);
  },
  onPageChanged: (index) {
    setState(() => _currentPage = index);
  },
)
```

---

## Temas e Estilo

### Theme Global

```dart
MaterialApp(
  theme: ThemeData(
    // Cores principais
    primarySwatch: Colors.blue,
    primaryColor: Color(0xFF2196F3),
    scaffoldBackgroundColor: Colors.white,
    
    // AppBar
    appBarTheme: AppBarTheme(
      backgroundColor: Colors.blue,
      foregroundColor: Colors.white,
      elevation: 2,
      centerTitle: true,
    ),
    
    // Textos
    textTheme: TextTheme(
      displayLarge: TextStyle(fontSize: 32, fontWeight: FontWeight.bold),
      displayMedium: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
      bodyLarge: TextStyle(fontSize: 16, color: Colors.black87),
      bodyMedium: TextStyle(fontSize: 14, color: Colors.black54),
    ),
    
    // Botões
    elevatedButtonTheme: ElevatedButtonThemeData(
      style: ElevatedButton.styleFrom(
        backgroundColor: Colors.blue,
        foregroundColor: Colors.white,
        padding: EdgeInsets.symmetric(horizontal: 24, vertical: 12),
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(8),
        ),
      ),
    ),
    
    // Inputs
    inputDecorationTheme: InputDecorationTheme(
      border: OutlineInputBorder(),
      focusedBorder: OutlineInputBorder(
        borderSide: BorderSide(color: Colors.blue, width: 2),
      ),
    ),
  ),
  darkTheme: ThemeData.dark().copyWith(
    // Tema escuro
  ),
  themeMode: ThemeMode.system,  // Segue sistema, ou .light, ou .dark
)
```

### Usar tema no widget

```dart
@override
Widget build(BuildContext context) {
  final theme = Theme.of(context);
  
  return Text(
    'Texto',
    style: theme.textTheme.displayLarge,
  );
  
  return Container(
    color: theme.primaryColor,
  );
}
```

### Estilos de Texto

```dart
Text(
  'Meu texto',
  style: TextStyle(
    fontSize: 16,
    fontWeight: FontWeight.bold,
    fontStyle: FontStyle.italic,
    color: Colors.blue,
    letterSpacing: 1.2,
    wordSpacing: 2.0,
    decoration: TextDecoration.underline,
    decorationColor: Colors.red,
    shadows: [
      Shadow(
        blurRadius: 10.0,
        color: Colors.black45,
        offset: Offset(2, 2),
      ),
    ],
  ),
  textAlign: TextAlign.center,
  maxLines: 2,
  overflow: TextOverflow.ellipsis,
)
```

---

## Boas Práticas

### 1. Organização de Projeto

```
lib/
├── main.dart
├── app.dart                 # MaterialApp config
├── core/
│   ├── constants/
│   │   ├── colors.dart
│   │   ├── strings.dart
│   │   └── routes.dart
│   ├── theme/
│   │   └── app_theme.dart
│   └── utils/
│       ├── validators.dart
│       └── formatters.dart
├── models/
│   ├── user.dart
│   └── product.dart
├── services/
│   ├── api_service.dart
│   ├── auth_service.dart
│   └── storage_service.dart
├── providers/            # ou bloc/, ou controllers/
│   ├── auth_provider.dart
│   └── cart_provider.dart
├── screens/
│   ├── home/
│   │   ├── home_screen.dart
│   │   └── widgets/
│   │       ├── home_card.dart
│   │       └── home_list.dart
│   ├── login/
│   │   └── login_screen.dart
│   └── profile/
│       └── profile_screen.dart
└── widgets/
    ├── custom_button.dart
    ├── custom_card.dart
    └── loading_indicator.dart
```

### 2. Const Everywhere (Performance!)

```dart
// ✅ BOM - widget não reconstrói
const Text('Hello')
const Icon(Icons.home)
const SizedBox(height: 16)

// ❌ RUIM - reconstrói desnecessariamente
Text('Hello')
Icon(Icons.home)

// Use const quando possível, economiza muito rebuild!
```

### 3. Extract Widgets

```dart
// ❌ RUIM - build muito grande
@override
Widget build(BuildContext context) {
  return Scaffold(
    body: Column(
      children: [
        Container(...), // 50 linhas
        Row(...),       // 30 linhas
        ListView(...),  // 100 linhas
      ],
    ),
  );
}

// ✅ BOM - widgets pequenos e reutilizáveis
@override
Widget build(BuildContext context) {
  return Scaffold(
    body: Column(
      children: [
        _buildHeader(),
        _buildActions(),
        _buildList(),
      ],
    ),
  );
}

Widget _buildHeader() => HeaderWidget();
Widget _buildActions() => ActionsRow();
Widget _buildList() => ItemsList();
```

### 4. Dispose Controllers

```dart
// SEMPRE dispose de controllers e streams!
class _MyWidgetState extends State<MyWidget> {
  final _controller = TextEditingController();
  final _scrollController = ScrollController();
  late StreamSubscription _subscription;

  @override
  void dispose() {
    _controller.dispose();
    _scrollController.dispose();
    _subscription.cancel();
    super.dispose();
  }
}
```

### 5. Null Safety

```dart
// ? - pode ser null
String? nome;

// ! - force unwrap (cuidado!)
print(nome!);  // Crash se for null

// ?? - default value
String displayName = nome ?? 'Anônimo';

// ?. - safe navigation
int? length = nome?.length;

// Cascade notation
final pessoa = Pessoa()
  ..nome = 'João'
  ..idade = 30
  ..email = 'joao@email.com';
```

### 6. Async/Await

```dart
// ✅ BOM
Future<void> loadData() async {
  setState(() => _loading = true);
  try {
    final data = await api.fetchData();
    setState(() {
      _data = data;
      _loading = false;
    });
  } catch (e) {
    setState(() {
      _error = e.toString();
      _loading = false;
    });
  }
}

// Multiple awaits em paralelo
final results = await Future.wait([
  api.getUsers(),
  api.getProducts(),
  api.getOrders(),
]);
```

### 7. BuildContext depois de async

```dart
// ❌ RUIM - context pode ser inválido
Future<void> submit() async {
  await api.save(data);
  Navigator.pop(context);  // Pode crashar!
}

// ✅ BOM - verifica se mounted
Future<void> submit() async {
  await api.save(data);
  if (mounted) {
    Navigator.pop(context);
  }
}

// Ou guarda antes do await
Future<void> submit() async {
  final navigator = Navigator.of(context);
  await api.save(data);
  navigator.pop();
}
```

### 8. Debug Prints

```dart
import 'package:flutter/foundation.dart';

// Use debugPrint ao invés de print
debugPrint('Mensagem de debug');

// Só roda em debug mode
if (kDebugMode) {
  print('Debug info');
}

// Só roda em release mode
if (kReleaseMode) {
  // Enviar analytics, etc
}
```

---

## Packages Essenciais

```yaml
dependencies:
  # State Management
  provider: ^6.0.0           # Estado global simples
  riverpod: ^2.3.0           # Estado moderno e seguro
  get: ^4.6.5                # All-in-one (estado, rotas, deps)
  
  # HTTP
  http: ^1.1.0               # Cliente HTTP básico
  dio: ^5.3.0                # HTTP completo (interceptors, etc)
  
  # Storage Local
  shared_preferences: ^2.2.0 # Key-value simples
  hive: ^2.2.3               # NoSQL local rápido
  sqflite: ^2.3.0            # SQLite
  
  # Formatação
  intl: ^0.18.0              # Datas, números, i18n
  
  # UI
  flutter_svg: ^2.0.7        # SVG
  cached_network_image: ^3.2.3  # Cache de imagens
  shimmer: ^3.0.0            # Loading skeleton
  lottie: ^2.6.0             # Animações Lottie
  
  # Utils
  path_provider: ^2.1.0      # Paths do sistema
  url_launcher: ^6.1.14      # Abrir URLs/tel/email
  share_plus: ^7.1.0         # Compartilhar conteúdo
  image_picker: ^1.0.4       # Camera/galeria
  permission_handler: ^11.0.0 # Permissões
  
  # Firebase
  firebase_core: ^2.15.1
  firebase_auth: ^4.9.0
  cloud_firestore: ^4.9.1
  
  # Dev
  flutter_lints: ^2.0.0      # Linter

dev_dependencies:
  flutter_test:
    sdk: flutter
  build_runner: ^2.4.6       # Code generation
  mockito: ^5.4.2            # Mocks para testes
```

---

## Comandos Úteis de Debug

```dart
// Imprimir árvore de widgets
debugDumpApp();

// Imprimir render tree
debugDumpRenderTree();

// Imprimir layer tree
debugDumpLayerTree();

// Performance overlay (mostra FPS)
MaterialApp(
  showPerformanceOverlay: true,
)

// Debug paint (mostra bounds)
MaterialApp(
  debugShowCheckedModeBanner: false,  // Remove banner DEBUG
  showSemanticsDebugger: true,        // Acessibilidade
)
```

---

## Links Úteis

- **Documentação Oficial**: https://docs.flutter.dev/
- **Pub.dev** (packages): https://pub.dev/
- **Flutter Samples**: https://flutter.github.io/samples/
- **Widget Catalog**: https://docs.flutter.dev/ui/widgets
- **Cookbook**: https://docs.flutter.dev/cookbook
- **DartPad** (playground online): https://dartpad.dev/

---

## Atalhos VS Code

- `stless` → Stateless Widget
- `stful` → Stateful Widget
- `Ctrl + .` → Quick Fix / Refactor
- `Ctrl + Shift + R` → Refactor
- Wrap with Widget: `Ctrl + .` → Wrap with...
- Extract Method: `Ctrl + .` → Extract Method
- Hot Reload: `Ctrl + F5` ou `r` no terminal
- Hot Restart: `Ctrl + Shift + F5` ou `R` no terminal

---

## Próximos Passos

1. **Pratique com projetos reais**: Todo app, E-commerce, Clone de app famoso
2. **Aprenda testes**: Unit tests, Widget tests, Integration tests
3. **Estude arquitetura**: Clean Architecture, MVVM, BLoC pattern
4. **Firebase**: Auth, Firestore, Storage, Notifications
5. **Animações avançadas**: Rive, Custom painters
6. **Native integration**: Platform channels para código nativo
7. **Performance**: DevTools, profiling, otimizações
8. **CI/CD**: GitHub Actions, Codemagic, Fastlane

---

**Dica Final**: Flutter é muito mais rápido que web para desenvolver. Use hot reload sem medo, experimente, quebre coisas. O erro vai te ensinar mais que qualquer tutorial.

Boa sorte! 🚀
 - O const no construtor permite que você crie instâncias constantes do widget. Isso traz benefícios importantes:

1. Performance no Flutter, quando você marca um construtor como const, o Flutter pode:
- Evitar reconstruir o widget se os parâmetros não mudaram
- Reusar a mesma instância em memória
- Melhorar performance em listas grandes

2. Garante Imutabilidade, o const força que todos os campos sejam final, garantindo que o widget seja imutável (boa prática em Flutter).

3. Auto-complete do VS Code, o VS Code sugere const porque detectou que na classe:
```dart
class TransactionList extends StatelessWidget {
  final List<Transaction> transactions;

  const TransactionList({super.key, required this.transactions});
  
  @override
  Widget build(BuildContext context) {
    return const Placeholder();
  }
}
```
- Seu widget estende StatelessWidget (que é imutável)
- Você tem final no campo transactions
- Está usando super.key (padrão moderno)
- Anatomia do construtor:

const: Permite instâncias constantes
super.key: Sintaxe moderna (Flutter 3.0+) para passar o key para o StatelessWidget
required: Torna o parâmetro obrigatório
this.transactions: Atalho que atribui automaticamente ao campo transactions
É uma boa prática manter o const - o auto-complete fez a coisa certa! 👍

---

**ESTILO E ALINHAMENTO**
conhecimento flutter

container
child - aceita exatamente um widget como filho
alinhamento flexivel e opções de estilo
largura flexivel (largura do filho, largura disponivel...)
perfeito para linhamento e estilo personalizado


column / row
children - aceita uma lista de filhos
possui alinhamento, mas sem opção de estilo
column - sempre ocupa toda altura disponivel / row - sempre ocupa toda largura
    - da pra usar o eixo cruzado para com a opção strech ocupar todo o espaço cruzado
usado quando os widgets estiverem próximos ou acima um do outro