$Entity = Read-Host "Name of Entity "

$Repos = Read-Host "What is the Plural of the Entity?"

$Repository="{0}Repo" -f $Entity;
$subString= $Entity.substring(0,1);

$lEntity='{0}'-f $Entity.substring(0,1).tolower()+$Entity.substring(1);

Function Add_Entity{

$EntityFolder =
"C:\Users\Leah\source\repos\BO-API\BO_API\Entities\"
$NewEntity=@"
using System;
using System.Collections.Generic;


namespace BO_API.Entities
{
    public partial class $Entity :IEntityBase
    {

        public int $($Entity)Id { get; set;}
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

"@

if(Test-Path "$($EntityFolder)$($Entity).cs" )
{
Remove-Item "$($EntityFolder)$($Entity).cs"
}
New-Item -Path "$EntityFolder" -Name "$($Entity).cs"  -ItemType "file" -Value $INewEntity


}

Function Add_IRepository{
$RepoInterfaceFolder="C:\Users\Leah\source\repos\BO-API\BO_API\IRepo\"

$IRepoInterface = @"

using System.Threading.Tasks;
using BO_API.Entities;

namespace BO_API.IRepo

{
    public interface I$($Entity)Repo :IRepo<$($Entity)>
    {

    }
}
"@

if(Test-Path "$($RepoInterfaceFolder)I$($Entity)Repo.cs" )
{
Remove-Item -Path "$($RepoInterfaceFolder)I$($Entity)Repo.cs"
}

New-Item -Path "$RepoInterfaceFolder"  -Name "I$($Entity)Repo.cs" -ItemType "file" -Value $IRepoInterface

}




Function Add_Repository{
$RepoFolder= "C:\Users\Leah\source\repos\BO-API\BO_API\Repo\"

$IRepo=@"

using BO_API.Entities;
using BO_API.IRepo;
using BO_API.EntityFramework; 

namespace BO_API.Repo
{
    public class $($Entity)Repo : Repo<$($Entity)>, I$($Entity)Repo
    {
        private BOContext _context;
        public $($Entity)Repo(BOContext context) : base(context)
        {
            _context = context;
        }
    }
}


"@



if(Test-Path "$($RepoFolder)$($Entity)Repo.cs" )
{
Remove-Item -Path "$($RepoFolder)$($Entity)Repo.cs"
}
New-Item -Path "$RepoFolder"  -Name "$($Entity)Repo.cs" -ItemType "file" -Value $IRepo


}

Function AddToContex{

$cArray = Get-Content -Path @("C:\Users\Leah\source\repos\BO-API\BO_API\EntityFramework\BOContext.cs")


$toAdd= "         public DbSet<$($Entity)> $($Repos) {get; set;}"


for($i=0; $i -lt $cArray.Length; $i++){

$findSubstring= "//"+$subString; 

if($cArray[$i] -match $findSubstring)
{
$index= $cArray.IndexOf($cArray[$i]);
}



}


$new_array = @($cArray[0..$index]) + @($toAdd) +

@($cArray[($index+1)..$cArray.Length])

if(Test-Path "C:\Users\Leah\source\repos\BO-API\BO_API\EntityFramework\BOContext.cs")
{
Remove-Item -Path "C:\Users\Leah\source\repos\BO-API\BO_API\EntityFramework\BOContext.cs"
}
New-Item -Path "C:\Users\Leah\source\repos\BO-API\BO_API\EntityFramework\" -Name "BOContext.cs" -ItemType "file"

$new_array | Out-File -Append "C:\Users\Leah\source\repos\BO-API\BO_API\EntityFramework\BOContext.cs"


}

Add_Repository;

Add_IRepository;

AddToContex;

<#
Function Add_UnitTestBuilder{
$UnitTestBuilderFolder =
"C:\Users\Leah\source\repos\BO-API\BO_API\UnitTests\"
$UnitTestBuilder=@"

using System;
using System.Collections.Generic;
using System.Text;


namespace UnitTest.Builders
{
    public static class $($Entity)Builder
    {
       public static $Entity Build()
       {
          return new $Entity()
          {
              $($Entity)Id=0,
              CreatedBy=1
          };

       }
    }
}
"@

if(Test-Path "$($UnitTestBuilderFolder)$($Entity)Builder.cs" )
{
Remove-Item -Path "$($UnitTestBuilderFolder)$($Entity)Builder.cs"
}
New-Item -Path "$UnitTestBuilderFolder"  -Name "$($Entity)Builder.cs"
-ItemType "file" -Value $UnitTestBuilder


}


Function Add_UniteTest{


$GenericUnitTestFolder="C:\Users\leahr\source\repos"

$GenericUnitTest = @"
using NUnit.Framework;

using System;

using System.Threading.Tasks;

namespace UnitTest.Repository.TestsForGenericRepos
{
    [TestFixture]
    public class $($Entity)GenericRepoTest : UnitTestBase
    {
        $Entity _$($lEntity)Obj;
        $Entity $($lEntity)Obj = new $Entity();

        [SetUp]
        public new void Setup()
        {
            _$($lEntity)Obj = $($Entity)Builder.Build();
        }

        [Test, Order(1)]
        public async Task Create_$($Entity)_$($Entity)Id_Should_Not_Be_Zero()
        {

            $($unitOfWork).$($Repos).Add(_$($lEntity)Obj);
            await _unitOfWork.Complete();
            $($lEntity)Obj = _$($lEntity)Obj;
            Assert.AreNotEqual(0, $($lEntity)Obj.$($Entity)Id);
        }

        [Test, Order(2)]
        public async Task $($Entity)_List_Should_Be_Greater_Than_0()
        {

            var $($lEntity)List= await $($unitOfWork).$($Repos).List();
            Assert.IsNotEmpty($($lEntity)List);
        }

        [Test, Order(3)]
        public async Task Update$($Entity)Repo()
        {
          //update entityObj
            $($lEntity)Obj.ModifiedBy=2;
            $($lEntity)Obj.ModifiedDate= DateTime.Now;
            $($unitOfWork).$($Repos).Update($($lEntity)Obj);
            await _unitOfWork.Complete();
            Assert.IsTrue($($lEntity)Obj.ModifiedBy == 2);
        }

        [Test, Order(4)]
        public async Task Get_$($Entity)_by_$($Entity)Id()
        {
            var found$($Entity) = await
$($unitOfWork).$($Repos).GetByIdAsync($($lEntity)Obj.$($Entity)Id);
            Assert.AreEqual(found$($Entity).$($Entity)Id,
$($lEntity)Obj.$($Entity)Id);
        }

        [Test, Order(5)]
        public async Task Deleted_$($Entity)_Should_Not_Be_In_DB()
        {
            var id = $($lEntity)Obj.$($Entity)Id;
            $($unitOfWork).$($Repos).Delete($($lEntity)Obj);
            await $($unitOfWork).Complete();
            var found$($Entity)Obj = await
$($unitOfWork).$($Repos).GetByIdAsync(id);
            Assert.IsNull(found$($Entity)Obj);
        }

    }
}
"@




if(Test-Path "$($GenericUnitTestFolder)$($Entity)GenericRepoTests.cs" )
{
Remove-Item -Path "$($GenericUnitTestFolder)$($Entity)GenericRepoTests.cs"
}
New-Item -Path "$GenericUnitTestFolder"  -Name"$($Entity)GenericRepoTest.cs" -ItemType "file" -Value
$GenericUnitTest






 }





Function Update_UnitTest{

$array = Get-Content -Path
@("C:\Users\leahr\source\repos\")
$lRepo='{0}'-f $Repository.substring(0,1).tolower()+$Repository.substring(1);

$repoA= "             var  _$($lRepo) = new $($Repository)(_dbContext); "
$repoB= "             _$($lRepo),"

$lineA="//1$($substring)"
$lineB="//2$($substring)"

for($i=0; $i -lt $array.Length; $i++){

if($array[$i] -match $lineA )
{
$indexA= $array.IndexOf($array[$i]);
}

if($array[$i] -match $lineB )
{
$indexB= $array.IndexOf($array[$i]);
}

}


$new_array = @($array[0..$indexA]) + @($repoA) +
@($array[($indexA+1)..$indexB]) + @($repoB) +
@($array[($indexB+1)..$array.Length])

if(Test-Path "C:\Users\leahr\source\repos")
{
Remove-Item -Path
"C:\Users\leahr\source\reposs"
}
New-Item -Path "C:\Users\leahr\source"
 -Name "UnitTestBase.cs" -ItemType "file"

$new_array | Out-File -Append
"C:\Users\leahr\source\repos"


}


Add_Entity;

#>
