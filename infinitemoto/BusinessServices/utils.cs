
public static class Utils
{
 public static string saveImg(IFormFile img, string  ImgFor)
    {
       /// Save image to the server
       /// 
        string upLoadPath    = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        if(!Directory.Exists(upLoadPath))
        {
           Directory.CreateDirectory(upLoadPath);
        }
         
        string fileName = ImgFor + "_" + Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
        string filePath = Path.Combine(upLoadPath, fileName);
        using(var stream = new FileStream(filePath, FileMode.Create))
        {
                img.CopyTo(stream);
        }
        return fileName;
    }
}