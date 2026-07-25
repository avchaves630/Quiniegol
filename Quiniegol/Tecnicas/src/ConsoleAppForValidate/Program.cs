using ClassExampleController;
using ClassExampleModels;

internal class Program
{
    private static void Main(string[] args)
    {
        var userController = new UserController(new FileHandler<User>());
        var controller = new LoginController(userController);
        var user = "anunez@example.com";
        var pass = "123";

        var result = controller.Login(user, pass);

        if (result)
        {
            Console.WriteLine("inicio de sesion exitoso");
        }
        else
        {
            Console.WriteLine("inicio de sesion no exitoso");
        }

        Console.WriteLine("Hello, World!");
    }
}