using System;
using System.Collections.Generic;
using System.Text;
using WorkoutTracker2.Model;
using SQLite;
using System.Threading.Tasks;

namespace WorkoutTracker2.Data
{
    public class WorkoutDatabase
    {
        readonly SQLiteAsyncConnection database;

        public WorkoutDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);  //Instantiate database Connection
            database.CreateTableAsync<Workout>().Wait();   //Initialize Tables
            database.CreateTableAsync<WeightLog>().Wait();
            database.CreateTableAsync<Exercise>().Wait();
            database.CreateTableAsync<Set>().Wait();
        }

        public Task<List<Workout>> GetWorkoutsAsync()
        {
            return database.Table<Workout>().ToListAsync();
        }

        public Task<Workout> GetWorkoutAsync(int id)
        {
            return database.Table<Workout>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        
        

        public Task<int> SaveWorkoutAsync(Workout workout)
        {
            if(workout.Id != 0)
            {
                return database.UpdateAsync(workout);
            }
            else
            {
                return database.InsertAsync(workout);
            }
        }

        public Task<int> DeleteWorkoutAsync(Workout workout)
        {
            return database.DeleteAsync(workout);
        }



        //====================================================================================================
        //Weights
        //====================================================================================================

        public Task<List<WeightLog>> GetWeightsAsync()
        {
            return database.Table<WeightLog>().ToListAsync();
        }

        public Task<WeightLog> GetWeightAsync(int id)
        {
            return database.Table<WeightLog>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveWeightAsync(WeightLog weightlog)
        {
            if (weightlog.Id != 0)
            {
                return database.UpdateAsync(weightlog);
            }
            else
            {
                return database.InsertAsync(weightlog);
            }
        }

        public Task<int> DeleteWeightAsync(WeightLog weightlog)
        {
            return database.DeleteAsync(weightlog);
        }

        //====================================================================================================
        //Exercises
        //====================================================================================================

        public Task<List<Exercise>> GetExercisesAsync()
        {
            return database.Table<Exercise>().ToListAsync();
        }

        public Task<Exercise> GetExerciseAsync(int id)
        {
            return database.Table<Exercise>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        
        public Task<List<Exercise>> GetExercisesByWorkoutAsync(int WorkoutId)
        {
            return database.QueryAsync<Exercise>($"SELECT DISTINCT Exercise.Name, Exercise.Sets FROM Exercise, Workout WHERE Exercise.WorkoutId = {WorkoutId}");
        }
        
        public Task<int> SaveExerciseAsync(Exercise Exercise)
        {
            if (Exercise.Id != 0)
            {
                return database.UpdateAsync(Exercise);
            }
            else
            {
                return database.InsertAsync(Exercise);
            }
        }

        public Task<int> DeleteExerciseAsync(Exercise Exercise)
        {
            return database.DeleteAsync(Exercise);
        }

        //====================================================================================================
        //Sets
        //====================================================================================================

        public Task<List<Set>> GetSetsAsync()
        {
            return database.Table<Set>().ToListAsync();
        }

        public Task<Set> GetSetAsync(int id)
        {
            return database.Table<Set>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Set>> GetSetsByExerciseAsync(int exerciseId)
        {
            return database.QueryAsync<Set>($"SELECT DISTINCT Set.SetNumber, Set.Reps, Set.Weight FROM Set, Exercise WHERE Set.ExerciseId = {exerciseId}");
        }

        public Task<int> SaveSetAsync(Set Set)
        {
            if (Set.Id != 0)
            {
                return database.UpdateAsync(Set);
            }
            else
            {
                return database.InsertAsync(Set);
            }
        }

        public Task<int> DeleteSetAsync(Set Set)
        {
            return database.DeleteAsync(Set);
        }
    }
}
