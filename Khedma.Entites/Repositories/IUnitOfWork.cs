﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        IMakhdoumReposiotry Makhdoum { get; }
        IKoralReposiotry Koral { get; }
        ITheStageReposiotry TheStage{ get; }
        IAlhanReposiotry Alhan{ get; }
        ILearningReposiotry Learning{ get; }
        ICopticReposiotry Coptic{ get; }
        ITheaterReposiotry Theater{ get; }
        IBooksAndSavesReposiotry BooksAndSaves{ get; }
        IForSingleRepository ForSingle { get; }
        IArtsReposiotry Arts { get; }
        IArtsNameReposiotry ArtsName{ get; }
        IForSingleNameReposiotry ForSingleName { get; }
        IUserReposiotry User { get; }
        IRoleReposiotry Role { get; }
        IUserRoleReposiotry UserRole { get; }
        ITheaterRoleeReposiotry TheaterRole { get;  }
        IAttendanceAlhanReposiotry AttendanceAlhan { get;  }
        IAttendanceKoralReposiotry AttendanceKoral { get; }
        IAttendanceLearningReposiotry AttendanceLearning { get; }
        IAttendanceCopticReposiotry AttendanceCoptic { get; }
        IAttendanceBookAndSavelReposiotry AttendanceBookAndSave { get; }

        int Complete();
    }
}
