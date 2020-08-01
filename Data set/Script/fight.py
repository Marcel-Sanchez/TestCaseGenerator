cases = 5

method = """
public class TestCase1 : AnagramasTest
    {
        public void Ejemplo1()
        {
            string str = "mom";
            Assert.That(Student(str), Is.EqualTo(CantidadEnCadena(str)));
        }
    }
"""

for i in range(cases):
    exec(method.format(i))

for i in range(num_users):
    exec('users.append(client' + str(i) + ')')
    f_name = str(i) + '.txt'
    exec('txt_names.append(f_name)')
    with open(txt_names[i], 'w+') as f:
        f.writelines(['False\n', 'Forest\n', '1\n'])

