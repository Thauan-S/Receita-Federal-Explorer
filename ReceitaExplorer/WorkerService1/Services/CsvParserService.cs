

using CsvHelper.Configuration;
using CsvHelper;
using System.Text;
using WorkerService1.Entityes;
using WorkerService1.Repositories.CnaeRepository;
using WorkerService1.Repositories.EmpresaRepository;
using WorkerService1.Repositories.MunicipioRepository;
using WorkerService1.Repositories.PaisRepository;
using WorkerService1.Repositories.MotivoRepository;
using WorkerService1.Repositories.QualificacoesRepository;
using WorkerService1.Repositories.NaturezaJuridicaRepository;

namespace WorkerService1.Services
{
    public class CsvParserService:ICSVParserService
    {
        private readonly ILogger<CsvParserService> _logger;
        private readonly ICnaeRepository _cnaeRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IPaisRepository _paisRepository;
        private readonly IMotivoRepository _motivoRepository;
        private readonly IQualificacaoRepository _qualificacaoSocioRepository;
        private readonly INaturezaRepository _naturezaJuridicaRepository;

        public CsvParserService(ILogger<CsvParserService> logger, ICnaeRepository cnaeRepository, IEmpresaRepository empresaRepository, IMunicipioRepository municipioRepository, IPaisRepository paisRepository, IMotivoRepository motivoRepository, IQualificacaoRepository qualificacaoSocioRepository, INaturezaRepository naturezaJuridicaRepository)
        {
            _logger = logger;
            _cnaeRepository = cnaeRepository;
            _empresaRepository = empresaRepository;
            _municipioRepository = municipioRepository;
            _paisRepository = paisRepository;
            _motivoRepository = motivoRepository;
            _qualificacaoSocioRepository = qualificacaoSocioRepository;
            _naturezaJuridicaRepository = naturezaJuridicaRepository;
        }

        public async Task<List<Entity>> ParseToEntities<Entity, EntityMap>(string CSVfilePath)
          where EntityMap : ClassMap<Entity> where Entity : class
        {
            Pais? pais;
            QualificacaoSocio? qualificacaoSocio;
            Motivo? motivo;
            NaturezaJuridica? naturezaJuridica;

            using (var reader = new StreamReader(CSVfilePath, encoding: Encoding.Latin1))
            using (var csv = new CsvReader(reader, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                HasHeaderRecord = false,
                Delimiter = ";",
                BadDataFound = null,
                HeaderValidated = null,
                MissingFieldFound = null
            }))
            {
                try
                {
                    csv.Context.RegisterClassMap<EntityMap>();

                    List<Entity>? datas = null;

                    if (typeof(Entity) == typeof(Empresa))
                    {
                        datas = csv.GetRecords<Entity>()
                             .ToList();
                        var naturezasJuridicas = await _naturezaJuridicaRepository.FindAll();
                        foreach (var empresa in (datas as List<Empresa>)!)
                        {
                            naturezaJuridica = naturezasJuridicas
                                                .FirstOrDefault(n => n.Codigo.Equals(empresa.IdNaturezaJuridica));
                            if (naturezaJuridica == null)
                            {
                                empresa.IdNaturezaJuridica = null;
                            }
                        }
                        return datas;
                    }
                    if (typeof(Entity) == typeof(Socio))
                    {
                        datas = csv.GetRecords<Entity>()
                            .ToList();

                        foreach (var socio in (datas as List<Socio>)!)
                        {

                            var empresa = await _empresaRepository.FindByIdAsync(socio.IdEmpresa);
                            if (empresa == null)
                            {
                                socio.IdEmpresa = null;
                            }

                            pais = await _paisRepository.FindByIdAsync(socio.IdPais);
                            if (pais == null)
                            {
                                socio.IdPais = null;
                            }

                            qualificacaoSocio = await _qualificacaoSocioRepository
                                                           .FindByIdAsync(socio.IdQualificacaoSocio);
                            if (qualificacaoSocio == null)
                            {
                                socio.IdQualificacaoSocio = null;
                            }
                        }
                        return datas;
                    }
                    if (typeof(Entity) == typeof(Estabelecimento))
                    {
                        datas = csv.GetRecords<Entity>()
                            .ToList();

                        foreach (var est in (datas as List<Estabelecimento>)!)
                        {
                            var empresa = await _empresaRepository.FindByIdAsync(est.IdEmpresa);
                            if (empresa == null)
                            {
                                est.IdEmpresa = null;
                            }
                            pais = await _paisRepository.FindByIdAsync(est.IdPais);
                            if (pais == null)
                            {
                                est.IdPais = null;
                            }
                            motivo = await _motivoRepository.FindByIdAsync(est.IdMotivo);
                            if (motivo == null)
                            {
                                est.IdMotivo = "01";
                            }
                            var municipio = await _municipioRepository.FindByIdAsync(est.IdMunicipio);
                            if (municipio == null)
                            {
                                est.IdMunicipio = null;
                            }
                            var cnae = await _cnaeRepository.FindByIdAsync(est.IdCnae);
                            if (cnae == null)
                            {
                                est.IdCnae = null;
                            }
                        }
                        return datas;
                    }
                    if (typeof(Entity) == typeof(Simples))
                    {
                        datas = csv.GetRecords<Entity>()
                             .ToList();

                        foreach (var simp in (datas as List<Simples>)!)
                        {
                            var empresa = await _empresaRepository.FindByIdAsync(simp.IdEmpresa);
                            if (empresa == null)
                            {
                                simp.IdEmpresa = null;
                            }
                        }
                        return datas;
                    }
                    datas = csv.GetRecords<Entity>().ToList();


                    return datas;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error:" + ex.Message);
                    return [];
                }

            }
        }
    }
}
