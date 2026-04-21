using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Tercuman.Contracts.DTOs.Listing;


namespace Tercuman.Application.Validators
    {
        public class CreateListingValidator : AbstractValidator<CreateListingDto>
        {
            public CreateListingValidator()
            {
                RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Başlık boş olamaz")
                    .MaximumLength(700).WithMessage("Başlık en fazla 700 karakter olabilir");

            RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("Açıklama boş olamaz")
                    .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir");

                RuleFor(x => x.Price)
                    .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalı");

                RuleFor(x => x.CityId)
                    .NotEmpty().WithMessage("Şehir seçmelisin");

                RuleFor(x => x.SourceLanguageId)
                    .NotEmpty().WithMessage("Kaynak dil seçmelisin");

                RuleFor(x => x.TargetLanguageId)
                    .NotEmpty().WithMessage("Hedef dil seçmelisin");
            }
        }
    }

