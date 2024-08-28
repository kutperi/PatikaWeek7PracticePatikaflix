using PatikaWeek7PracticePatikaflix;

List<Serial> serials = new List<Serial>();
bool continueAdding = true;

Console.WriteLine("Patikaflix'e Hoşgeldiniz!");

while (continueAdding) // Sürekli dizi girmeye yarayacak loop
{
    Console.WriteLine("Dizi bilgilerini giriniz: ");

    Serial newSerial = new Serial();

    Console.WriteLine("Dizi Adı: ");
    newSerial.Name = Console.ReadLine();

    Console.WriteLine("Yapım Yılı: ");
    newSerial.ProductionYear = int.Parse(Console.ReadLine());

    Console.WriteLine("Tür: ");
    newSerial.Genre = Console.ReadLine();

    Console.WriteLine("Yayınlanma Yılı: ");
    newSerial.PublicationYear = int.Parse(Console.ReadLine());

    Console.WriteLine("Yönetmen: ");
    newSerial.Director = Console.ReadLine();

    Console.WriteLine("Yayınlandığı İlk Platform: ");
    newSerial.Platform = Console.ReadLine();

    serials.Add(newSerial);

    Console.WriteLine("Yeni bir dizi daha oluşturmak ister misiniz? (E/H): ");
    string response = Console.ReadLine();
    continueAdding = response.Trim().ToUpper() == "E";

}

Console.WriteLine("---------- DİZİ LİSTESİ -----------");

foreach (var serial in serials) // Oluşturulan dizilerin hepsi
{
    Console.WriteLine($"Adı: {serial.Name}, Yapım Yılı: {serial.ProductionYear}, Tür: {serial.Genre}, Yayın Yılı: {serial.PublicationYear}, Yönetmen: {serial.Director}, Platform: {serial.Platform}");
}

Console.WriteLine("-----------------------------------");

List<ComedySerial> comedySerials = serials.Where(serial => serial.Genre.Trim().ToLower() == "komedi") // Sadece komedi dizileri alındı
                                    .Select(serial => new ComedySerial // Select komutu ile dizinin belli özellikleri alındı
                                    {
                                        Name = serial.Name,
                                        Genre = serial.Genre,
                                        Director = serial.Director
                                    }).ToList();

var orderComedySerials = comedySerials.OrderBy(serial => serial.Name)
                                      .ThenBy(serial => serial.Director);

Console.WriteLine("-------------- KOMEDİ DİZİLERİ ---------------");

foreach(var serial in orderComedySerials) 
{
    Console.WriteLine($"Adı: {serial.Name}, Director: {serial.Director}, Tür: {serial.Genre}");
}



